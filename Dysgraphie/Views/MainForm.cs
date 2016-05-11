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


namespace Dysgraphie.Views
{
    public partial class MainForm : Form
    {
        private CWintabContext m_logContext = null;
        private CWintabData m_wtData = null;
        private AcquisitionPoint acquisition;

        private int pointID = 0;
        private DrawingThread drawingThread;
        DateTime start;



        // These constants can be used to force Wintab X/Y data to map into a
        // a 10000 x 10000 grid, as an example of mapping tablet data to values
        // that make sense for your application.
        private const Int32 m_TABEXTX = 10000;
        private const Int32 m_TABEXTY = 10000;

        

        public MainForm()
        {
            InitializeComponent();
            InitData();

            start = DateTime.Now;
            bool controlSystemCursor = true;
            this.FormClosing += new FormClosingEventHandler(TestForm_FormClosing);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitDataCapture(m_TABEXTX, m_TABEXTY, controlSystemCursor);

        }

        private void InitData()
        {
            drawingThread = new DrawingThread(this.picBoard);
            drawingThread.Start();
            acquisition = new AcquisitionPoint();
            acquisition.Start();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
        
        private void TestForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            CloseCurrentContext();
        }

        private void CloseCurrentContext()
        {
            try
            {

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
               // Console.Write(ex.ToString());
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
                //logContext = CWintabInfo.GetDefaultDigitizingContext(ECTXOptionValues.CXO_MESSAGES);
                logContext = CWintabInfo.GetDefaultSystemContext(ECTXOptionValues.CXO_MESSAGES);

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

                // SetSystemExtents() is (almost) a NO-OP redundant if you opened a system context.
                SetSystemExtents(ref logContext);

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

                if (pkt.pkContext != 0)
                {

                    Datas.Point p = new Datas.Point(this.pointID, 0, Convert.ToDouble(DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond)/1000, pkt.pkX, pkt.pkY, pkt.pkZ, pkt.pkNormalPressure, pkt.pkOrientation.orAltitude, pkt.pkOrientation.orAzimuth, pkt.pkOrientation.orTwist);
                    acquisition.AddPoint(p);
                    this.pointID++;
                    
                    if (pkt.pkNormalPressure != 0)
                    {
                        
                        System.Drawing.Point convertedP = picBoard.PointToClient(new System.Drawing.Point(pkt.pkX, pkt.pkY));
                        drawingThread.AddPoint(new DrawingPoint(convertedP.X, convertedP.Y, pkt.pkNormalPressure));
                        

                    }

                    textBoxPrintNumber.Text = acquisition.getNumberOfPrint().ToString();
                    textBoxTime.Text = (Convert.ToDouble(DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond) / 1000 - acquisition.analysis.points.ElementAt(0).t).ToString();
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
                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception("FAILED to get packet data: " + ex.ToString());
            }
        }
        private void SetSystemExtents(ref CWintabContext logContext)
        {
            
            logContext.OutExtY = -logContext.OutExtY;
        }

       
    }
}
