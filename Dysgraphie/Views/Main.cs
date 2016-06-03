using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Dysgraphie.Drawing;
using WintabDN;
using Dysgraphie.Acquisition;
using Dysgraphie.Database;
using System.IO;
using System.Diagnostics;
using Dysgraphie.Indicators;
using Dysgraphie.Utils;

namespace Dysgraphie.Views
{
    public partial class Main : Form
    {
        private String state = "stopped";
        private System.Timers.Timer timer = new System.Timers.Timer(1000);
        private TimeSpan temps;
        private System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
        private Char[] characters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
        private List<char> sequence = new List<Char>();
        private int nbTxt = 0;
        private Child child;
        private String path;
        private Boolean basicMode = true;
        private String selectedDB;
		private DbManager manager;
        private List<Analysis> analysis;
        private AcquisitionPoint acquisition;

        public Main()
        {
            InitializeComponent();
            timer.Elapsed += new ElapsedEventHandler(TimerIncrement);

            InitData();
            this.FormClosing += new FormClosingEventHandler(TestForm_FormClosing);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;


            this.analysis = new List<Analysis>();
            InitDataCapture(m_TABEXTX, m_TABEXTY, true);
            m_logContext = OpenTestSystemContext();
            InitData();

            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "data")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "data"));
            }
            initToolStripMenuDB();
        }

        private void initToolStripMenuDB()
        {
            String path = Path.Combine(Environment.CurrentDirectory, "data");
            DirectoryInfo d = new DirectoryInfo(path);
            bool first = true;
            foreach (var file in d.GetFiles("*.sqlite"))
            {
                String dbName = file.Name.Replace(".sqlite", "");
                if (first)
                {
                    selectedDB = dbName;
                    manager = new DbManager(selectedDB);
                }
                addToolStripItemDB(dbName, first);
                first = false;
            }
        }

        private void addToolStripItemDB(String itemName, bool check)
        {
            choixDeLaBaseToolStripMenuItem.Enabled = true;
            accéderAuxDonnéesToolStripMenuItem.Enabled = true;
            ToolStripMenuItem newItem = new System.Windows.Forms.ToolStripMenuItem();
            newItem.Checked = check;
            newItem.Name = itemName.Replace(" ", "");
            newItem.Size = new System.Drawing.Size(152, 22);
            newItem.Text = itemName;
            newItem.Click += new System.EventHandler(this.database_Click);
            this.choixDeLaBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {newItem});
        }

		private void saveBtn_Click(object sender, EventArgs e)
        {
            save();
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New n = new New();
            DialogResult result = n.ShowDialog();
            if(result == DialogResult.OK)
            {
                child = n.child;
                path = n.path;
                Init();
            }
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Charger un fichier";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.picBoard.Invalidate();
                this.analysis = OpenSaveTrace.openSequence(openFileDialog1.FileName);
                this.richtextBoxX.Text = OpenSaveTrace.getSequenceCommentary(openFileDialog1.FileName);

                textBoxPrintNumber.Text = acquisition.getNumberOfPrint().ToString();
                this.textBoxBreakTime.Text = acquisition.getBreakTime().ToString();
                this.textBoxDrawTime.Text = acquisition.getDrawTime().ToString();
                this.textBoxDrawLength.Text = acquisition.getDrawLength().ToString();
                this.textBoxAverageSpeed.Text = acquisition.getAverageSpeed().ToString();
                this.textBoxHeightLetter.Text = acquisition.getLettersHeight().ToString();
                this.textBoxWidthLetter.Text = acquisition.getLettersWidth().ToString();

                

                DrawingPoint dp;
                foreach(Analysis a in this.analysis)
                {
                    foreach (Datas.Point p in a.points)
                    {
                        double y = Convert.ToDouble(p.y);
                        double x = Convert.ToDouble(p.x);

                        if (p.p > 0)
                        {

                            dp = new DrawingPoint(Convert.ToInt32(x / 65024 * picBoard.Size.Width), Convert.ToInt32(y / 40640 * picBoard.Size.Height), p.p, p.id);
                            drawingThread.AddPoint(dp);
                        }
                    }
                }
                    
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case "stopped":
                    Start();
                    break;
                case "started":
                    Pause();
                    break;
                case "paused":
                    Continue();
                    break;
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            nextTxt();
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void basiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.basiqueToolStripMenuItem.Checked)
            {
                this.basiqueToolStripMenuItem.Checked = true;
                this.analyseToolStripMenuItem.Checked = false;
                basicMode = true;
                if (child != null)
                {
                    this.infoPanel.Visible = true;
                }
                this.analysePanel.Visible = false;
            }
        }

        private void analyseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.analyseToolStripMenuItem.Checked)
            {
                this.basiqueToolStripMenuItem.Checked = false;
                this.analyseToolStripMenuItem.Checked = true;
                basicMode = false;
                this.infoPanel.Visible = false;
                this.analysePanel.Visible = true;
            }
        }

        private void createBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String dbName = "Base 1";
            DialogResult dbResult = InputBox.ShowInputBox("Création d'une nouvelle base", "Nom de la base :", ref dbName);
            if(dbResult == DialogResult.OK)
            {
                createBase(dbName);
                selectedDB = dbName;
                manager = new DbManager(selectedDB);
            }
        }

        private void database_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem dbItem = (ToolStripMenuItem)sender;
            if(!dbItem.Checked)
            {
                foreach (ToolStripMenuItem item in this.choixDeLaBaseToolStripMenuItem.DropDownItems)
                {
                    item.Checked = false;
                }
                dbItem.Checked = true;
                selectedDB = dbItem.Text;
                manager = new DbManager(selectedDB);
            }
        }

        private void accéderAuxDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String DBname = selectedDB + ".sqlite";
            String path = Path.Combine(Environment.CurrentDirectory, "data", DBname);
            String SQLiteStudioPath = Path.Combine(Environment.CurrentDirectory, "SQLiteStudio", "SQLiteStudio.exe");
            if (File.Exists(path) && File.Exists(SQLiteStudioPath))
            {
                path = "\"" + path + "\"";
                SQLiteStudioPath = "\"" + SQLiteStudioPath + "\"";
                Process.Start(SQLiteStudioPath, path);
            }
            else
            {
                MessageBox.Show("Il semblerait que SQLiteStudio ne se trouve plus dans le répertoire de l'application ou que la base sélectionnée a été supprimée.\n\nVérifiez que le logiciel SQLiteStudio ainsi que tout ses composants sont présents dans le répertoire de l'application à l'intérieur du dossier SQLiteStudio.", "Erreur", MessageBoxButtons.OK);
            }
        }

        private void TimerIncrement(object source, ElapsedEventArgs e)
        {
            temps += TimeSpan.FromMilliseconds(timer.Interval);
            this.timerLabel.Text = temps.ToString();
        }

        private void Init()
        {
            Random r = new Random();
            List<char> c = new List<Char>();
            sequence.Clear();
            for (int i = 0; i < characters.Length; i++)
            {
                c.Add(characters[i]);
            }
            for (int i = 0; i < characters.Length; i++)
            {
                int nb = r.Next(c.Count - 1);
                sequence.Add(c[nb]);
                c.RemoveAt(nb);
            }
            this.textLabel.Text = "";
            this.nameLabel.Text = child.GetNom();
            this.forenameLabel.Text = child.GetPrenom();
            this.birthLabel.Text = child.GetDateN().ToString();
            this.ageLabel.Text = child.GetAge().ToString();
            this.gradeLabel.Text = child.GetClasse();
            this.lateralityLabel.Text = child.GetLateralite();
            this.genderLabel.Text = child.GetGenre();
            if(basicMode)
            {
                this.infoPanel.Visible = true;
            }
            this.startBtn.Enabled = true;
        }

        private void Start()
        {
            state = "started";
            this.startBtn.Image = ((System.Drawing.Image)(Properties.Resources.pause));
            this.startBtn.Text = "Pause";
            this.stopBtn.Enabled = true;
            this.nextBtn.Enabled = true;
            temps = new TimeSpan();
            timer.Start();
            this.restartBtn.Enabled = false;
            this.saveBtn.Enabled = false;
            this.resultsBtn.Enabled = false;
            nbTxt = 0;
            this.textLabel.Text = sequence[nbTxt].ToString();

            this.InitData();
            this.acquisition.analysis.character = sequence[nbTxt];
        }

        private void Stop()
        {
            if(state != "stopped")
            {
                state = "stopped";
                this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
                this.startBtn.Text = "Démarrer";
                this.startBtn.Enabled = false;
                this.eraseBtn.Enabled = false;
                this.stopBtn.Enabled = false;
                timer.Stop();
                this.restartBtn.Enabled = true;
                this.saveBtn.Enabled = true;
                this.resultsBtn.Enabled = true;
                this.nextBtn.Enabled = false;
                this.ajouterÀLaBaseToolStripMenuItem.Enabled = true;
                this.InitData();
            }
        }

        private void Continue()
        {
            state = "started";
            this.startBtn.Image = ((System.Drawing.Image)(Properties.Resources.pause));
            this.startBtn.Text = "Pause";
            timer.Start();
        }

        private void Pause()
        {
            state = "paused";
            timer.Stop();
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.Text = "Reprendre";
        }

        private void nextTxt()
        {
            nbTxt++;

            this.analysis.Add(this.acquisition.analysis);
            this.acquisition.Reset();
            this.picBoard.Invalidate();
            
            if (nbTxt+1 <= sequence.Count)
            {
                this.acquisition.analysis.character = sequence[nbTxt];
                this.textLabel.Text = sequence[nbTxt].ToString();
                
            }
            else
            {
                end();
            }
        }

        private void end()
        {
            this.nextBtn.Enabled = false;
            this.textLabel.Text = "";
            this.restartBtn.Enabled = true;
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.Text = "Démarrer";
            this.startBtn.Enabled = false;
            this.eraseBtn.Enabled = false;
            this.stopBtn.Enabled = false;
            this.saveBtn.Enabled = true;
            this.resultsBtn.Enabled = true;
            this.ajouterÀLaBaseToolStripMenuItem.Enabled = true;
            timer.Stop();
        }

        private void restart()
        {
            DialogResult restartResult = MessageBox.Show("Etes-vous sûr de vouloir recommencer ? Les tracés seront supprimés.", "Recommencer ?", MessageBoxButtons.YesNo);
            if (restartResult == DialogResult.Yes)
            {
                state = "stopped";
                this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
                this.startBtn.Text = "Démarrer";
                this.startBtn.Enabled = true;
                this.nextBtn.Enabled = false;
                this.stopBtn.Enabled = false;
                this.resultsBtn.Enabled = false;
                this.restartBtn.Enabled = false;
                this.saveBtn.Enabled = false;
                this.eraseBtn.Enabled = true;
                this.ajouterÀLaBaseToolStripMenuItem.Enabled = false;
                this.timerLabel.Text = "00:00:00";
            }
        }

        private void createBase(String dbName)
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "data")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "data"));
            }
            DbManager newDB = new DbManager(dbName);
            newDB.CreateDB();
            foreach (ToolStripMenuItem item in this.choixDeLaBaseToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            addToolStripItemDB(dbName, true);
        }

        // Code tablette

        private CWintabContext m_logContext = null;
        private CWintabData m_wtData = null;

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

        
        private void InitData()
        {
            drawingThread = new DrawingThread(this.picBoard);
            drawingThread.Start();

            this.analysis = new List<Analysis>();
            this.acquisition = new AcquisitionPoint();

            this.acquisition.Start();
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

                if (this.pointID == 0)
                {
                    this.initTime = pkt.pkTime;
                }

                if (pkt.pkContext != 0)
                {
                    if (pkt.pkZ < this.seuilZ)
                    {

                    }
                    Datas.Point p = new Datas.Point(this.pointID, pkt.pkSerialNumber, Convert.ToDouble(pkt.pkTime - this.initTime), pkt.pkX, pkt.pkY, pkt.pkZ, pkt.pkNormalPressure, pkt.pkOrientation.orAltitude, pkt.pkOrientation.orAzimuth, pkt.pkOrientation.orTwist);
                    this.acquisition.AddPoint(p);
                    this.pointID++;

                    if (pkt.pkNormalPressure != 0)
                    {
                        double y = Convert.ToDouble(pkt.pkY);
                        double x = Convert.ToDouble(pkt.pkX);

                        DrawingPoint dp = new DrawingPoint(Convert.ToInt32(x / m_logContext.InExtX * picBoard.Size.Width), Convert.ToInt32(y / m_logContext.InExtY * picBoard.Size.Height), pkt.pkNormalPressure, this.pointID);
                        drawingThread.AddPoint(dp);


                    }

                    this.textBoxX.Text = pkt.pkX.ToString();
                    this.textBoxY.Text = pkt.pkY.ToString();
                    this.textBoxZ.Text = pkt.pkZ.ToString();
                    this.textBoxPression.Text = pkt.pkNormalPressure.ToString();
                    this.textBoxAltitude.Text = pkt.pkOrientation.orAltitude.ToString();
                    this.textBoxAzimuth.Text = pkt.pkOrientation.orAzimuth.ToString();
                    this.textBoxTwist.Text = pkt.pkOrientation.orTwist.ToString();
                    this.textBoxDrawTime.Text = this.acquisition.getDrawTime().ToString();
                    this.textBoxBreakTime.Text = this.acquisition.getBreakTime().ToString();
                    this.textBoxDrawLength.Text = this.acquisition.getDrawLength().ToString();
                    this.textBoxPrintNumber.Text = this.acquisition.getNumberOfPrint().ToString();
                    this.textBoxPrintNumber.Text = this.acquisition.getNumberOfPrint().ToString();
                    this.textBoxHeightLetter.Text = this.acquisition.analysis.lettersHeight.ToString();
                    this.textBoxWidthLetter.Text = this.acquisition.analysis.lettersWidth.ToString();
                    this.textBoxAverageSpeed.Text = this.acquisition.getAverageSpeed().ToString();
                    

                }
                /*
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
                */

            }
            catch (Exception ex)
            {
                throw new Exception("FAILED to get packet data: " + ex.ToString());
            }
        }

        //-------------------------------------------------------------------------


        private void eraseBtn_Click(object sender, EventArgs e)
        {
            this.picBoard.Invalidate();
            this.acquisition.Reset();
            if(this.sequence.Count != 0)
            {
                this.acquisition.analysis.character = this.sequence[this.nbTxt];
            }
        }
       


        private void save()
        {
            OpenSaveTrace.saveSequence(this.analysis, this.path+"\\traces.txt", this.richtextBoxX.Text);
        }

        private void toolStripBDD_Click(object sender, EventArgs e)
        {

            
            ChildDatas cd;
            int IdChild = manager.getCurrentChildID() + 1;
            this.child.SetID(IdChild);
            if (!child.alreadySaved(manager)) child.AddChildInDB(manager);    
            foreach(Analysis a in this.analysis)
            {
                cd = new ChildDatas(child.GetID(), a.character, a);
                cd.saveDatas(manager);
            }
        }

        private void resultsBtn_Click(object sender, EventArgs e)
        {
            Diagnostic d = new Diagnostic(manager, child, analysis);

            Dictionary<string, int> indicators = d.resultsPerIndicator();

            foreach (KeyValuePair<string, int> keyValInd in indicators)
            {
                Console.WriteLine(keyValInd.Key + " : " + keyValInd.Value.ToString()+"/36");
            }


            Dictionary<char, int> letters = d.resultsPerLetter();

            foreach (KeyValuePair<char, int> keyValLetter in letters)
            {
                Console.WriteLine(keyValLetter.Key + " : " + keyValLetter.Value.ToString()+"/11");
            }
        }

        private void ajouterÀLaBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildDatas cd;
            int IdChild = manager.getCurrentChildID() + 1;
            this.child.SetID(IdChild);
            if (!child.alreadySaved(manager)) child.AddChildInDB(manager);
            foreach (Analysis a in this.analysis)
            {
                cd = new ChildDatas(child.GetID(), a.character, a);
                cd.saveDatas(manager);
            }
        }
    }
}
