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
using Dysgraphie.OutputFiles;
using System.Xml.Serialization;

namespace Dysgraphie.Views
{
    //Interface principale
    public partial class Main : Form
    {
        // Etat du test stopped, paused, started
        private String state = "stopped";

        // Timer pour le test
        private System.Timers.Timer timer = new System.Timers.Timer(1000);
        private TimeSpan temps;

        // Accès aux resources
        private System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));

        // Suite de caractères
        private Char[] letters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        private Char[] numbers = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        private List<char> sequence = new List<Char>();
        private int nbTxt = 0;

        // Les données de l'enfant et chemin du répertoire de travail
        private Child child;
        private String path;

        // Mode basique ou analyse
        private Boolean basicMode = true;

        // Base sélectionnée
        private String selectedDB;

        // Gestion de la DB
		private DbManager manager;

        // Pour l'acquisition des données et l'analyse des critères
        private List<Analysis> analysis;
        private AcquisitionPoint acquisition;

        public Main()
        {
            InitializeComponent();
            timer.Elapsed += new ElapsedEventHandler(TimerIncrement);

            InitData();
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

        // Parser les DB et les afficher dans le menu
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

        // Ajout d'une DB en élément  du menu
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

        // Handler du bouton enregistrer
		private void saveBtn_Click(object sender, EventArgs e)
        {
            save();
        }

        // Handler du bouton nouveau ouvrir la vue New
        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New n = new New();

            DialogResult result = n.ShowDialog();
            if(result == DialogResult.OK)
            {
                child = n.child;
                path = n.path;
                Console.WriteLine(path);
                Init();
            }
        }

        // Handler du bouton ouvrir et gestion des données à charger
        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Charger un fichier";
            openFileDialog1.Filter = "XML Files (*.xml)|*.xml|Text Files (.txt)|*.txt";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String traceFile = "";
                string ext = Path.GetExtension(openFileDialog1.FileName);
                if(ext == ".txt")
                {
                    traceFile = openFileDialog1.FileName;
                    this.analysePanel.Visible = true;
                    this.infoPanel.Visible = false;
                    this.basiqueToolStripMenuItem.Checked = false;
                    this.analyseToolStripMenuItem.Checked = true;
                    this.basicMode = false;
                    this.resultsBtn.Enabled = false;
                    this.groupBoxTxt.Visible = false;
                    child = null;
                }
                if(ext == ".xml")
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Child));
                    StreamReader reader = new StreamReader(openFileDialog1.FileName);
                    child = (Child)serializer.Deserialize(reader);
                    reader.Close();

                    this.nameLabel.Text = child.Nom;
                    this.forenameLabel.Text = child.Prenom;
                    this.birthLabel.Text = child.DateN.ToString();
                    this.ageLabel.Text = child.Age.ToString();
                    this.gradeLabel.Text = child.Classe;
                    this.lateralityLabel.Text = child.Lateralite;
                    this.genderLabel.Text = child.Genre;
                    this.richtextBoxX.Text = child.Commentaire;
                    this.analysePanel.Visible = false;
                    this.infoPanel.Visible = true;
                    this.basiqueToolStripMenuItem.Checked = true;
                    this.analyseToolStripMenuItem.Checked = false;
                    this.basicMode = true;
                    this.resultsBtn.Enabled = true;
                    this.groupBoxTxt.Visible = false;
                    this.path = Path.GetDirectoryName(openFileDialog1.FileName);
                    traceFile = Path.Combine(this.path, "traces.txt");
                }
                if (File.Exists(traceFile))
                {
                    this.picBoard.Invalidate();
                    this.analysis = OpenSaveTrace.openSequence(traceFile);
                    this.richtextBoxX.Text = OpenSaveTrace.getSequenceCommentary(traceFile);

                    textBoxPrintNumber.Text = acquisition.getNumberOfPrint().ToString();
                    this.textBoxBreakTime.Text = acquisition.getBreakTime().ToString();
                    this.textBoxDrawTime.Text = acquisition.getDrawTime().ToString();
                    this.textBoxDrawLength.Text = acquisition.getDrawLength().ToString();
                    this.textBoxAverageSpeed.Text = acquisition.getAverageSpeed().ToString();
                    this.textBoxHeightLetter.Text = acquisition.getLettersHeight().ToString();
                    this.textBoxWidthLetter.Text = acquisition.getLettersWidth().ToString();

                    this.startBtn.Enabled = false;
                    this.eraseBtn.Enabled = false;
                    this.restartBtn.Enabled = false;
                    this.stopBtn.Enabled = false;
                    this.saveBtn.Enabled = false;
                    this.enregistrerToolStripMenuItem.Enabled = false;
                    this.comboBoxCharacter.Visible = true;
                    this.comboBoxCharacterInfo.Visible = true;

                    DrawingPoint dp;
                    Analysis a = this.analysis.ElementAt(0);
                    this.comboBoxCharacter.SelectedItem = Convert.ToString(a.character);
                    this.comboBoxCharacterInfo.SelectedItem = Convert.ToString(a.character);
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

        // Handler du bouton quitter
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Handler du bouton commencer (on gère les états)
        private void startBtn_Click(object sender, EventArgs e)
        {
            erase();
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

        // Handler du bouton stop
        private void stopBtn_Click(object sender, EventArgs e)
        {
            Stop();
        }

        // Handler du bouton next
        private void nextBtn_Click(object sender, EventArgs e)
        {
            nextTxt();
        }

        // Handler du bouton recommencer
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

        // Handler des checkbox button du menu pour le choix du mode 
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

        // Handler pour la création d'une DB
        private void createBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Nom par défaut
            String dbName = "Base 1";

            // Ouvrir la dialog pour le choix du nom
            DialogResult dbResult = InputBox.ShowInputBox("Création d'une nouvelle base", "Nom de la base :", ref dbName);
            if(dbResult == DialogResult.OK)
            {
                createBase(dbName);
                selectedDB = dbName;
                manager = new DbManager(selectedDB);
            }
        }

        // Handler sur un bouton d'une DB à choisir dans le menu
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

        // Handler pour visualiser les données de DB : ouvrir SQLiteStudio
        private void accéderAuxDonnéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String DBname = selectedDB + ".sqlite";
            String DBpath = Path.Combine(Environment.CurrentDirectory, "data", DBname);
            String SQLiteStudioPath = Path.Combine(Environment.CurrentDirectory, "SQLiteStudio", "SQLiteStudio.exe");
            if (File.Exists(DBpath) && File.Exists(SQLiteStudioPath))
            {
                DBpath = "\"" + DBpath + "\"";
                SQLiteStudioPath = "\"" + SQLiteStudioPath + "\"";
                Process.Start(SQLiteStudioPath, DBpath);
            }
            else
            {
                MessageBox.Show("Il semblerait que SQLiteStudio ne se trouve plus dans le répertoire de l'application ou que la base sélectionnée a été supprimée.\n\nVérifiez que le logiciel SQLiteStudio ainsi que tout ses composants sont présents dans le répertoire de l'application à l'intérieur du dossier SQLiteStudio.", "Erreur", MessageBoxButtons.OK);
            }
        }

        // Handler des touches droite et espace
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.nextBtn.Enabled && (e.KeyCode == Keys.Space || e.KeyCode == Keys.Right))
            {
                nextTxt();
            }
        }

        // Incrémenter le timer toutes les secondes
        private void TimerIncrement(object source, ElapsedEventArgs e)
        {
            temps += TimeSpan.FromMilliseconds(timer.Interval);
            this.timerLabel.Text = temps.ToString();
        }

        // Initialiser la vue, les états et les données
        private void Init()
        {
            state = "stopped";
            Console.WriteLine(state);
            Random r = new Random();
            List<char> c = new List<Char>();
            sequence.Clear();
            for (int i = 0; i < letters.Length; i++)
            {
                c.Add(letters[i]);
            }
            for (int i = 0; i < letters.Length; i++)
            {
                int nb = r.Next(c.Count - 1);
                sequence.Add(c[nb]);
                c.RemoveAt(nb);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                c.Add(numbers[i]);
            }
            for (int i = 0; i < numbers.Length; i++)
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
            this.eraseBtn.Enabled = true;
            this.comboBoxCharacter.Visible = false;
            this.comboBoxCharacterInfo.Visible = false;
            this.groupBoxTxt.Visible = true;
            erase();
            nbTxt = 0;
            if (this.sequence.Count != 0)
            {
                this.acquisition.analysis.character = this.sequence[this.nbTxt];
            }
            foreach(Control ctrl in this.analysePanel.Controls)
            {
                if(ctrl is TextBox)
                {
                    ctrl.Text = "";
                }
            }
        }

        // Démarrer le test
        private void Start()
        {
            state = "started";
            this.startBtn.Image = ((System.Drawing.Image)(Properties.Resources.pause));
            this.startBtn.Text = "Pause";
            this.eraseBtn.Enabled = true;
            this.stopBtn.Enabled = true;
            this.nextBtn.Enabled = true;
            temps = new TimeSpan();
            timer.Start();
            this.restartBtn.Enabled = false;
            this.saveBtn.Enabled = false;
            this.enregistrerToolStripMenuItem.Enabled = false;
            this.resultsBtn.Enabled = false;
            nbTxt = 0;
            this.textLabel.Text = sequence[nbTxt].ToString();

            this.InitData();
            this.acquisition.analysis.character = sequence[nbTxt];
        }

        // Arrêter le test
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
                this.enregistrerToolStripMenuItem.Enabled = true;
                this.resultsBtn.Enabled = true;
                this.nextBtn.Enabled = false;
                this.ajouterÀLaBaseToolStripMenuItem.Enabled = true;                
            }
        }

        // Reprendre le test
        private void Continue()
        {
            state = "started";
            this.startBtn.Image = ((System.Drawing.Image)(Properties.Resources.pause));
            this.startBtn.Text = "Pause";
            timer.Start();
        }

        // Mettre en pause le test
        private void Pause()
        {
            state = "paused";
            timer.Stop();
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.Text = "Reprendre";
        }

        // Passer au caractère suivant
        private void nextTxt()
        {
            nbTxt++;

            this.analysis.Add(this.acquisition.analysis);
            erase();
            
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

        // Terminer le test
        private void end()
        {
            state = "stopped";
            this.nextBtn.Enabled = false;
            this.textLabel.Text = "";
            this.restartBtn.Enabled = true;
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.Text = "Démarrer";
            this.startBtn.Enabled = false;
            this.eraseBtn.Enabled = false;
            this.stopBtn.Enabled = false;
            this.saveBtn.Enabled = true;
            this.enregistrerToolStripMenuItem.Enabled = true;
            this.resultsBtn.Enabled = true;
            this.ajouterÀLaBaseToolStripMenuItem.Enabled = true;
            timer.Stop();
        }

        // Recommencer le test
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
                this.enregistrerToolStripMenuItem.Enabled = false;
                this.eraseBtn.Enabled = true;
                this.ajouterÀLaBaseToolStripMenuItem.Enabled = false;
                this.timerLabel.Text = "00:00:00";
            }
        }

        // Créer une nouvelle base
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

        // Code tablette //

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

        //Initialisation des données concernant l'acquisition des points
        private void InitData()
        {
            drawingThread = new DrawingThread(this.picBoard);
            drawingThread.Start();

            this.analysis = new List<Analysis>();
            this.acquisition = new AcquisitionPoint();
            
            
            this.acquisition.Start();
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

        //Initialisation de la tablette
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

        //initialisation du context
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

        //evenement déclanché lorsque le stylet est détecté par la tablette
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
                
                //initialisation du temps
                if (this.pointID == 0)
                {
                    this.initTime = pkt.pkTime;
                }

                if (pkt.pkContext != 0)
                {
                    if (pkt.pkZ < this.seuilZ)
                    {

                    }
                    //ajout du point à liste
                    Datas.Point p = new Datas.Point(this.pointID, pkt.pkSerialNumber, Convert.ToDouble(pkt.pkTime - this.initTime), pkt.pkX, pkt.pkY, pkt.pkZ, pkt.pkNormalPressure, pkt.pkOrientation.orAltitude, pkt.pkOrientation.orAzimuth, pkt.pkOrientation.orTwist);
                    this.acquisition.AddPoint(p);
                    this.pointID++;

                    if (pkt.pkNormalPressure != 0)
                    {
                        double y = Convert.ToDouble(pkt.pkY);
                        double x = Convert.ToDouble(pkt.pkX);

                        //dessin du dernier point acquis
                        DrawingPoint dp = new DrawingPoint(Convert.ToInt32(x / m_logContext.InExtX * picBoard.Size.Width), Convert.ToInt32(y / m_logContext.InExtY * picBoard.Size.Height), pkt.pkNormalPressure, this.pointID);
                        drawingThread.AddPoint(dp);
                    }

                    //affichage des données en temps réel
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
                
            }
            catch (Exception ex)
            {
                throw new Exception("FAILED to get packet data: " + ex.ToString());
            }
        }

        //-------------------------------------------------------------------------

        // Handler du bouton effacer
        private void eraseBtn_Click(object sender, EventArgs e)
        {
            erase();
            if(state == "started" && this.sequence.Count != 0)
            {
                this.acquisition.analysis.character = this.sequence[this.nbTxt];
            }
        }
       
        //efface la trace dessinée
        private void erase()
        {
            this.picBoard.Invalidate();
            this.acquisition.Reset();
        }

        // Sauvegarder le test dans le répertoire de travail
        private void save()
        {
            // Sauvegarde des traces
            OpenSaveTrace.saveSequence(this.analysis, this.path+"\\traces.txt", this.richtextBoxX.Text);

            // Sauvegarde de l'enfant
            XmlSerializer serializer = new XmlSerializer(typeof(Child));
            StreamWriter writer = new StreamWriter(Path.Combine(this.path, "child.xml"), false);
            serializer.Serialize(writer, child);
            writer.Close();
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

        //Edition et ouverture du PDF
        private void resultsBtn_Click(object sender, EventArgs e)
        {
            GradeSelector gradeSelector = new GradeSelector(child.GetClasse());
            DialogResult result = gradeSelector.ShowDialog();
            if(result == DialogResult.OK)
            {
                String grade = gradeSelector.grade; //selection de la classe avec laquelle comparer les données acquises
                Diagnostic d = new Diagnostic(manager, child, analysis, grade);
                
                PdfManager pdf = new PdfManager("diagnostic"+grade+".pdf", this.path);
                pdf.Create(this.child, d, grade, this.richtextBoxX.Text);
                pdf.ClosePdf();
                Process.Start(this.path + "\\diagnostic" + grade + ".pdf");
            }
        }

        //ajout des données acquises à la base de données
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

        //chargement de données
        private void comboBoxCharacter_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxCharacterInfo.SelectedItem = this.comboBoxCharacter.Text;
            this.picBoard.Invalidate(); //efface le dessin en cours
            foreach(Analysis a in this.analysis)
            {
                if(a.character == Convert.ToChar(this.comboBoxCharacter.Text))
                {
                    this.acquisition.analysis = a;
                    this.textBoxDrawTime.Text = this.acquisition.getDrawTime().ToString();
                    this.textBoxBreakTime.Text = this.acquisition.getBreakTime().ToString();
                    this.textBoxDrawLength.Text = this.acquisition.getDrawLength().ToString();
                    this.textBoxPrintNumber.Text = this.acquisition.getNumberOfPrint().ToString();
                    this.textBoxPrintNumber.Text = this.acquisition.getNumberOfPrint().ToString();
                    this.textBoxHeightLetter.Text = this.acquisition.analysis.lettersHeight.ToString();
                    this.textBoxWidthLetter.Text = this.acquisition.analysis.lettersWidth.ToString();
                    this.textBoxAverageSpeed.Text = this.acquisition.getAverageSpeed().ToString();
                    
                    //dessin du dossier chargé
                    DrawingPoint dp;
                    foreach (Datas.Point p in acquisition.analysis.points)
                    {
                        double y = Convert.ToDouble(p.y);
                        double x = Convert.ToDouble(p.x);

                        if (p.p > 0)
                        {

                            dp = new DrawingPoint(Convert.ToInt32(x / m_logContext.InExtX * picBoard.Size.Width), Convert.ToInt32(y / m_logContext.InExtY * picBoard.Size.Height), p.p, p.id);
                            drawingThread.AddPoint(dp);
                        }
                    }
                    break;
                }
            }
        }

        // Handler de la combobox du choix de caractère quand on ouvre un fichier
        private void comboBoxCharacterInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxCharacter.SelectedItem = this.comboBoxCharacterInfo.Text;
            this.picBoard.Invalidate();
            foreach (Analysis a in this.analysis)
            {
                if (a.character == Convert.ToChar(this.comboBoxCharacterInfo.Text))
                {
                    this.acquisition.analysis = a;
                    this.textBoxDrawTime.Text = this.acquisition.getDrawTime().ToString();
                    this.textBoxBreakTime.Text = this.acquisition.getBreakTime().ToString();
                    this.textBoxDrawLength.Text = this.acquisition.getDrawLength().ToString();
                    this.textBoxPrintNumber.Text = this.acquisition.getNumberOfPrint().ToString();
                    this.textBoxPrintNumber.Text = this.acquisition.getNumberOfPrint().ToString();
                    this.textBoxHeightLetter.Text = this.acquisition.analysis.lettersHeight.ToString();
                    this.textBoxWidthLetter.Text = this.acquisition.analysis.lettersWidth.ToString();
                    this.textBoxAverageSpeed.Text = this.acquisition.getAverageSpeed().ToString();


                    DrawingPoint dp;
                    foreach (Datas.Point p in acquisition.analysis.points)
                    {
                        double y = Convert.ToDouble(p.y);
                        double x = Convert.ToDouble(p.x);

                        if (p.p > 0)
                        {

                            dp = new DrawingPoint(Convert.ToInt32(x / m_logContext.InExtX * picBoard.Size.Width), Convert.ToInt32(y / m_logContext.InExtY * picBoard.Size.Height), p.p, p.id);
                            drawingThread.AddPoint(dp);
                        }
                    }
                    break;
                }
            }
        }

        // Handler du bouton enregistrer de la barre d'outil
        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}
