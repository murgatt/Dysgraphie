using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WintabDN;
using Dysgraphie.Drawing;
using Dysgraphie.Datas;
using Dysgraphie.Acquisition;
using Dysgraphie.Utils;
using Dysgraphie.Database;

namespace Dysgraphie.Views
{
    public partial class MainForm : Form
    {
        private CWintabContext m_logContext = null;
        private CWintabData m_wtData = null;
        private AcquisitionPoint acquisition;

        private int pointID = 0;
        private DrawingThread drawingThread;

        //Lors d'un tracé, le paramètre Z peut être faible mais non nul alors que stylo reste sur la tablette
        private int seuilZ = 50;

        // These constants can be used to force Wintab X/Y data to map into a
        // a 10000 x 10000 grid, as an example of mapping tablet data to values
        // that make sense for your application.
        private const Int32 m_TABEXTX = 10000;
        private const Int32 m_TABEXTY = 10000;
        private uint initTime;

        public MainForm()
        {
            InitializeComponent();
            InitData();

            this.FormClosing += new FormClosingEventHandler(TestForm_FormClosing);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void InitData()
        {            
            drawingThread = new DrawingThread(this.picBoard);
            drawingThread.Start();
            this.acquisition = new AcquisitionPoint();
        }

        
        
        private void TestForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            CloseCurrentContext();
        }

        private void CloseCurrentContext()
        {
            try
            {
                Console.WriteLine("Closing context...\n");
                if (m_logContext != null)
                {
                    m_logContext.Close();
                    m_logContext = null;
                    m_wtData = null;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }


        private void InitDataCapture(int ctxWidth_I = m_TABEXTX, int ctxHeight_I = m_TABEXTY, bool ctrlSysCursor_I = true)
        {
            try
            {
                // Close context from any previous test.
                CloseCurrentContext();

                m_logContext = OpenTestSystemContext(ctxWidth_I, ctxHeight_I, ctrlSysCursor_I);

                if (m_logContext == null)
                {
                    Console.Write("Test_DataPacketQueueSize: FAILED OpenTestSystemContext - bailing out...\n");
                    return;
                }

                // Create a data object and set its WT_PACKET handler.
                m_wtData = new CWintabData(m_logContext);
                m_wtData.SetWTPacketEventHandler(MyWTPacketEventHandler);
            }
            catch (Exception ex)
            {
               Console.Write(ex.ToString());
            }
        }


        private CWintabContext OpenTestSystemContext(int width_I = m_TABEXTX, int height_I = m_TABEXTY, bool ctrlSysCursor = true)
        {
            bool status = false;
            CWintabContext logContext = null;

            try
            {
                // Get the default system context.
                // Default is to receive data events.
                logContext = CWintabInfo.GetDefaultDigitizingContext(ECTXOptionValues.CXO_MESSAGES);
                //logContext = CWintabInfo.GetDefaultSystemContext(ECTXOptionValues.CXO_MESSAGES);

                // Set system cursor if caller wants it.
                if (ctrlSysCursor)
                {
                    logContext.Options |= (uint)ECTXOptionValues.CXO_SYSTEM;
                }
                else
                {
                    logContext.Options &= ~(uint)ECTXOptionValues.CXO_SYSTEM;
                }

                if (logContext == null)
                {
                    Console.Write("FAILED to get default digitizing context.\n");
                    return null;
                }

                // Modify the digitizing region.
                logContext.Name = "WintabDN Event Data Context";

                WintabAxis tabletX = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_X);
                WintabAxis tabletY = CWintabInfo.GetTabletAxis(EAxisDimension.AXIS_Y);

                logContext.InOrgX = 0;
                logContext.InOrgY = 0;
                logContext.InExtX = tabletX.axMax;
                logContext.InExtY = tabletY.axMax;                

                // Open the context, which will also tell Wintab to send data packets.
                status = logContext.Open();

                Console.Write("Context Open: " + (status ? "PASSED [ctx=" + logContext.HCtx + "]" : "FAILED") + "\n");
            }
            catch (Exception ex)
            {
                Console.Write("OpenTestDigitizerContext ERROR: " + ex.ToString());
            }

            return logContext;
        }

        public void MyWTPacketEventHandler(Object sender_I, MessageReceivedEventArgs eventArgs_I)
        {
            //System.Diagnostics.Debug.WriteLine("Received WT_PACKET event");
            if (m_wtData == null)
            {
                return;
            }

            try
            {
                uint pktID = (uint)eventArgs_I.Message.WParam;

                WintabPacket pkt = m_wtData.GetDataPacket((uint)eventArgs_I.Message.LParam, pktID);

                if(this.pointID == 0)
                {
                    Console.WriteLine("temps "+pkt.pkTime);
                    this.initTime = pkt.pkTime;
                }

                if (pkt.pkContext != 0)
                {
                    if(pkt.pkZ < this.seuilZ)
                    {

                    }
                    Datas.Point p = new Datas.Point(this.pointID, pkt.pkSerialNumber, Convert.ToDouble(pkt.pkTime-this.initTime), pkt.pkX, pkt.pkY, pkt.pkZ, pkt.pkNormalPressure, pkt.pkOrientation.orAltitude, pkt.pkOrientation.orAzimuth, pkt.pkOrientation.orTwist);
                    acquisition.AddPoint(p);
                    this.pointID++;
                    
                    if (pkt.pkNormalPressure != 0)
                    {
                        double y = Convert.ToDouble(pkt.pkY);
                        double x = Convert.ToDouble(pkt.pkX);
                        
                        DrawingPoint dp = new DrawingPoint(Convert.ToInt32(x / m_logContext.InExtX * picBoard.Size.Width), Convert.ToInt32(y / m_logContext.InExtY * picBoard.Size.Height), pkt.pkNormalPressure, this.pointID);
                        drawingThread.AddPoint(dp);
                        

                    }

                    textBoxPrintNumber.Text = acquisition.getNumberOfPrint().ToString();
                    textBoxTime.Text = (Convert.ToDouble(pkt.pkTime - this.initTime)/1000).ToString();
                    TextBoxTempsPause.Text = acquisition.getBreakTime().ToString();
                    textBoxTempsTrace.Text = acquisition.getDrawTime().ToString();
                    textBoxLongTrace.Text = acquisition.getDrawLength().ToString();
                    textBoxPression.Text = pkt.pkNormalPressure.ToString();
                    textBoxX.Text = pkt.pkX.ToString();
                    textBoxY.Text = pkt.pkY.ToString();
                    textBoxZ.Text = pkt.pkZ.ToString();
                    textBoxAltitude.Text = pkt.pkOrientation.orAltitude.ToString();
                    textBoxAzimuth.Text = pkt.pkOrientation.orAzimuth.ToString();
                    textBoxTwist.Text = pkt.pkOrientation.orTwist.ToString();
                    textBoxAverageSpeed.Text = acquisition.getAverageSpeed().ToString();
                    textBoxLettersHeight.Text = acquisition.analysis.lettersHeight.ToString();
                    textBoxLettersWidth.Text = acquisition.analysis.lettersWidth.ToString();


                }
                if (this.acquisition.analysis.instantSpeed != null && pointID % 100 == 0)
                {
                    double som = 0;
                    foreach (double v in this.acquisition.analysis.instantSpeed)
                    {
                        som += v;
                    }
                    Console.WriteLine("Vitesse calculée : " + som / this.acquisition.analysis.instantSpeed.Count);

                    som = 0;
                    foreach (double v in this.acquisition.analysis.instantAcceleration)
                    {
                        som += v;
                    }
                    Console.WriteLine("Accélération calculée : " + som / this.acquisition.analysis.instantAcceleration.Count);
                }
                

            }
            catch (Exception ex)
            {
                throw new Exception("FAILED to get packet data: " + ex.ToString());
            }
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            if(this.button1.Text == "Start")
            {
                Console.WriteLine("passage à Stop");
                this.picBoard.Invalidate();
                InitDataCapture(m_TABEXTX, m_TABEXTY, true);
                m_logContext = OpenTestSystemContext();
                this.acquisition = new AcquisitionPoint();

                acquisition.Start();
                button1.Text = "Stop";
                this.sauvegarderToolStripMenuItem.Enabled = false;
                this.chargerToolStripMenuItem.Enabled = false;
                this.pointID = 0;

            } else if(this.button1.Text == "Stop")
            {
                Console.WriteLine("passage à Start");
                
                CloseCurrentContext();
                button1.Text = "Start";
                this.sauvegarderToolStripMenuItem.Enabled = true;
                this.chargerToolStripMenuItem.Enabled = true;
            }
        }

        private void MainForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            CloseCurrentContext();
        }
        

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Sauvegarder";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenSaveTrace.saveTrace(this.acquisition.analysis, saveFileDialog1.FileName);
            }
        }

        private void chargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Charger un fichier";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.picBoard.Invalidate();
                this.acquisition.analysis = OpenSaveTrace.openTrace(openFileDialog1.FileName);
                Console.WriteLine(openFileDialog1.FileName);
                textBoxPrintNumber.Text = acquisition.getNumberOfPrint().ToString();
                
                textBoxTime.Text = (Convert.ToDouble(DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond) / 1000 - acquisition.analysis.points.ElementAt(0).t).ToString();
                TextBoxTempsPause.Text = acquisition.getBreakTime().ToString();
                textBoxTempsTrace.Text = acquisition.getDrawTime().ToString();
                textBoxLongTrace.Text = acquisition.getDrawLength().ToString();
                /* textBoxPression.Text = pkt.pkNormalPressure.ToString();
                 textBoxX.Text = pkt.pkX.ToString();
                 textBoxY.Text = pkt.pkY.ToString();
                 textBoxZ.Text = pkt.pkZ.ToString();
                 textBoxAltitude.Text = pkt.pkOrientation.orAltitude.ToString();
                 textBoxAzimuth.Text = pkt.pkOrientation.orAzimuth.ToString();
                 textBoxTwist.Text = pkt.pkOrientation.orTwist.ToString();*/
                textBoxAverageSpeed.Text = acquisition.getAverageSpeed().ToString();
                
            }
  
        }        

        private void buttonAjoutBDD_Click(object sender, EventArgs e)
        {
            DbManager manager = new DbManager("kikouDB");
            int IdChild = manager.getCurrentChildID()+1;
            Child c = new Child(IdChild, this.textBoxNom.Text, this.textBoxPrenom.Text, Convert.ToInt32(this.numericUpDownAge.Value), this.comboBoxClasse.Text, this.comboBoxGenre.Text, this.comboBoxLateralite.Text);
            if (!c.alreadySaved(manager)) c.AddChildInDB(manager);
            
            
            ChildDatas cd = new ChildDatas(c.GetID(), Convert.ToChar(this.comboBoxSymbole.Text), this.acquisition.analysis);
            cd.saveDatas(manager);
        }
    }
}
