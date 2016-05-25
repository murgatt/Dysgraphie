namespace Dysgraphie.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBoard = new System.Windows.Forms.PictureBox();
            this.TextBoxTempsPause = new System.Windows.Forms.TextBox();
            this.textBoxTempsTrace = new System.Windows.Forms.TextBox();
            this.textBoxLongTrace = new System.Windows.Forms.TextBox();
            this.textBoxPression = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.textBoxAzimuth = new System.Windows.Forms.TextBox();
            this.textBoxAltitude = new System.Windows.Forms.TextBox();
            this.textBoxTwist = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPrintNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxAverageSpeed = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxLettersHeight = new System.Windows.Forms.TextBox();
            this.textBoxLettersWidth = new System.Windows.Forms.TextBox();
            this.Données = new System.Windows.Forms.TabControl();
            this.tabPageDonnees = new System.Windows.Forms.TabPage();
            this.tabPagePatient = new System.Windows.Forms.TabPage();
            this.comboBoxSymbole = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.comboBoxLateralite = new System.Windows.Forms.ComboBox();
            this.comboBoxGenre = new System.Windows.Forms.ComboBox();
            this.comboBoxClasse = new System.Windows.Forms.ComboBox();
            this.numericUpDownAge = new System.Windows.Forms.NumericUpDown();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonAjoutBDD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.Données.SuspendLayout();
            this.tabPageDonnees.SuspendLayout();
            this.tabPagePatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoard
            // 
            this.picBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoard.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picBoard.Location = new System.Drawing.Point(259, 31);
            this.picBoard.Name = "picBoard";
            this.picBoard.Size = new System.Drawing.Size(1638, 930);
            this.picBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBoard.TabIndex = 3;
            this.picBoard.TabStop = false;
            // 
            // TextBoxTempsPause
            // 
            this.TextBoxTempsPause.Location = new System.Drawing.Point(125, 12);
            this.TextBoxTempsPause.Name = "TextBoxTempsPause";
            this.TextBoxTempsPause.Size = new System.Drawing.Size(100, 20);
            this.TextBoxTempsPause.TabIndex = 4;
            // 
            // textBoxTempsTrace
            // 
            this.textBoxTempsTrace.Location = new System.Drawing.Point(125, 55);
            this.textBoxTempsTrace.Name = "textBoxTempsTrace";
            this.textBoxTempsTrace.Size = new System.Drawing.Size(100, 20);
            this.textBoxTempsTrace.TabIndex = 5;
            // 
            // textBoxLongTrace
            // 
            this.textBoxLongTrace.Location = new System.Drawing.Point(125, 97);
            this.textBoxLongTrace.Name = "textBoxLongTrace";
            this.textBoxLongTrace.Size = new System.Drawing.Size(100, 20);
            this.textBoxLongTrace.TabIndex = 6;
            // 
            // textBoxPression
            // 
            this.textBoxPression.Location = new System.Drawing.Point(125, 139);
            this.textBoxPression.Name = "textBoxPression";
            this.textBoxPression.Size = new System.Drawing.Size(100, 20);
            this.textBoxPression.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Temps de pause";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Temps du tracé";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Longueur du tracé";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Pression :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "X";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(125, 180);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Y";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(125, 224);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxY.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Z";
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(125, 268);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(100, 20);
            this.textBoxZ.TabIndex = 17;
            // 
            // textBoxAzimuth
            // 
            this.textBoxAzimuth.Location = new System.Drawing.Point(125, 354);
            this.textBoxAzimuth.Name = "textBoxAzimuth";
            this.textBoxAzimuth.Size = new System.Drawing.Size(100, 20);
            this.textBoxAzimuth.TabIndex = 18;
            // 
            // textBoxAltitude
            // 
            this.textBoxAltitude.Location = new System.Drawing.Point(125, 311);
            this.textBoxAltitude.Name = "textBoxAltitude";
            this.textBoxAltitude.Size = new System.Drawing.Size(100, 20);
            this.textBoxAltitude.TabIndex = 19;
            // 
            // textBoxTwist
            // 
            this.textBoxTwist.Location = new System.Drawing.Point(125, 398);
            this.textBoxTwist.Name = "textBoxTwist";
            this.textBoxTwist.Size = new System.Drawing.Size(100, 20);
            this.textBoxTwist.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 354);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Azimuth";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Altitude";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 398);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Twist";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 445);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Temps écoulé";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(125, 445);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxTime.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 488);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Nombre de blocs";
            // 
            // textBoxPrintNumber
            // 
            this.textBoxPrintNumber.Location = new System.Drawing.Point(125, 488);
            this.textBoxPrintNumber.Name = "textBoxPrintNumber";
            this.textBoxPrintNumber.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrintNumber.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 525);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Vitesse moyenne";
            // 
            // textBoxAverageSpeed
            // 
            this.textBoxAverageSpeed.Location = new System.Drawing.Point(125, 525);
            this.textBoxAverageSpeed.Name = "textBoxAverageSpeed";
            this.textBoxAverageSpeed.Size = new System.Drawing.Size(100, 20);
            this.textBoxAverageSpeed.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1916, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sauvegarderToolStripMenuItem,
            this.chargerToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // sauvegarderToolStripMenuItem
            // 
            this.sauvegarderToolStripMenuItem.Enabled = false;
            this.sauvegarderToolStripMenuItem.Name = "sauvegarderToolStripMenuItem";
            this.sauvegarderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sauvegarderToolStripMenuItem.Text = "Sauvegarder";
            this.sauvegarderToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderToolStripMenuItem_Click);
            // 
            // chargerToolStripMenuItem
            // 
            this.chargerToolStripMenuItem.Name = "chargerToolStripMenuItem";
            this.chargerToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.chargerToolStripMenuItem.Text = "Charger";
            this.chargerToolStripMenuItem.Click += new System.EventHandler(this.chargerToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 572);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Hauteur de lettre";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 609);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 34;
            this.label15.Text = "Largeur de lettre";
            // 
            // textBoxLettersHeight
            // 
            this.textBoxLettersHeight.Location = new System.Drawing.Point(125, 572);
            this.textBoxLettersHeight.Name = "textBoxLettersHeight";
            this.textBoxLettersHeight.Size = new System.Drawing.Size(100, 20);
            this.textBoxLettersHeight.TabIndex = 35;
            // 
            // textBoxLettersWidth
            // 
            this.textBoxLettersWidth.Location = new System.Drawing.Point(125, 606);
            this.textBoxLettersWidth.Name = "textBoxLettersWidth";
            this.textBoxLettersWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxLettersWidth.TabIndex = 36;
            // 
            // Données
            // 
            this.Données.Controls.Add(this.tabPageDonnees);
            this.Données.Controls.Add(this.tabPagePatient);
            this.Données.Location = new System.Drawing.Point(12, 60);
            this.Données.Name = "Données";
            this.Données.SelectedIndex = 0;
            this.Données.Size = new System.Drawing.Size(241, 750);
            this.Données.TabIndex = 37;
            // 
            // tabPageDonnees
            // 
            this.tabPageDonnees.Controls.Add(this.label1);
            this.tabPageDonnees.Controls.Add(this.textBoxLettersWidth);
            this.tabPageDonnees.Controls.Add(this.TextBoxTempsPause);
            this.tabPageDonnees.Controls.Add(this.textBoxLettersHeight);
            this.tabPageDonnees.Controls.Add(this.textBoxTempsTrace);
            this.tabPageDonnees.Controls.Add(this.label15);
            this.tabPageDonnees.Controls.Add(this.textBoxLongTrace);
            this.tabPageDonnees.Controls.Add(this.label14);
            this.tabPageDonnees.Controls.Add(this.textBoxPression);
            this.tabPageDonnees.Controls.Add(this.label2);
            this.tabPageDonnees.Controls.Add(this.textBoxAverageSpeed);
            this.tabPageDonnees.Controls.Add(this.label3);
            this.tabPageDonnees.Controls.Add(this.label13);
            this.tabPageDonnees.Controls.Add(this.label4);
            this.tabPageDonnees.Controls.Add(this.textBoxPrintNumber);
            this.tabPageDonnees.Controls.Add(this.textBoxX);
            this.tabPageDonnees.Controls.Add(this.label12);
            this.tabPageDonnees.Controls.Add(this.label5);
            this.tabPageDonnees.Controls.Add(this.textBoxTime);
            this.tabPageDonnees.Controls.Add(this.textBoxY);
            this.tabPageDonnees.Controls.Add(this.label11);
            this.tabPageDonnees.Controls.Add(this.label6);
            this.tabPageDonnees.Controls.Add(this.label10);
            this.tabPageDonnees.Controls.Add(this.label7);
            this.tabPageDonnees.Controls.Add(this.label9);
            this.tabPageDonnees.Controls.Add(this.textBoxZ);
            this.tabPageDonnees.Controls.Add(this.label8);
            this.tabPageDonnees.Controls.Add(this.textBoxAzimuth);
            this.tabPageDonnees.Controls.Add(this.textBoxTwist);
            this.tabPageDonnees.Controls.Add(this.textBoxAltitude);
            this.tabPageDonnees.Location = new System.Drawing.Point(4, 22);
            this.tabPageDonnees.Name = "tabPageDonnees";
            this.tabPageDonnees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDonnees.Size = new System.Drawing.Size(233, 724);
            this.tabPageDonnees.TabIndex = 0;
            this.tabPageDonnees.Text = "Données";
            this.tabPageDonnees.UseVisualStyleBackColor = true;
            // 
            // tabPagePatient
            // 
            this.tabPagePatient.Controls.Add(this.comboBoxSymbole);
            this.tabPagePatient.Controls.Add(this.label22);
            this.tabPagePatient.Controls.Add(this.comboBoxLateralite);
            this.tabPagePatient.Controls.Add(this.comboBoxGenre);
            this.tabPagePatient.Controls.Add(this.comboBoxClasse);
            this.tabPagePatient.Controls.Add(this.numericUpDownAge);
            this.tabPagePatient.Controls.Add(this.textBoxNom);
            this.tabPagePatient.Controls.Add(this.textBoxPrenom);
            this.tabPagePatient.Controls.Add(this.label21);
            this.tabPagePatient.Controls.Add(this.label20);
            this.tabPagePatient.Controls.Add(this.label19);
            this.tabPagePatient.Controls.Add(this.label18);
            this.tabPagePatient.Controls.Add(this.label17);
            this.tabPagePatient.Controls.Add(this.label16);
            this.tabPagePatient.Location = new System.Drawing.Point(4, 22);
            this.tabPagePatient.Name = "tabPagePatient";
            this.tabPagePatient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePatient.Size = new System.Drawing.Size(233, 724);
            this.tabPagePatient.TabIndex = 1;
            this.tabPagePatient.Text = "Patient";
            this.tabPagePatient.UseVisualStyleBackColor = true;
            // 
            // comboBoxSymbole
            // 
            this.comboBoxSymbole.FormattingEnabled = true;
            this.comboBoxSymbole.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0"});
            this.comboBoxSymbole.Location = new System.Drawing.Point(61, 349);
            this.comboBoxSymbole.Name = "comboBoxSymbole";
            this.comboBoxSymbole.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSymbole.TabIndex = 13;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 357);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 13);
            this.label22.TabIndex = 12;
            this.label22.Text = "Symbole";
            // 
            // comboBoxLateralite
            // 
            this.comboBoxLateralite.FormattingEnabled = true;
            this.comboBoxLateralite.Items.AddRange(new object[] {
            "Gaucher",
            "Droitier"});
            this.comboBoxLateralite.Location = new System.Drawing.Point(61, 172);
            this.comboBoxLateralite.Name = "comboBoxLateralite";
            this.comboBoxLateralite.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLateralite.TabIndex = 11;
            // 
            // comboBoxGenre
            // 
            this.comboBoxGenre.FormattingEnabled = true;
            this.comboBoxGenre.Items.AddRange(new object[] {
            "F",
            "M"});
            this.comboBoxGenre.Location = new System.Drawing.Point(57, 135);
            this.comboBoxGenre.Name = "comboBoxGenre";
            this.comboBoxGenre.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGenre.TabIndex = 10;
            // 
            // comboBoxClasse
            // 
            this.comboBoxClasse.FormattingEnabled = true;
            this.comboBoxClasse.Items.AddRange(new object[] {
            "CP",
            "CE1",
            "CE2",
            "CM1",
            "CM2"});
            this.comboBoxClasse.Location = new System.Drawing.Point(57, 98);
            this.comboBoxClasse.Name = "comboBoxClasse";
            this.comboBoxClasse.Size = new System.Drawing.Size(121, 21);
            this.comboBoxClasse.TabIndex = 9;
            // 
            // numericUpDownAge
            // 
            this.numericUpDownAge.Location = new System.Drawing.Point(57, 63);
            this.numericUpDownAge.Name = "numericUpDownAge";
            this.numericUpDownAge.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownAge.TabIndex = 8;
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(57, 34);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(100, 20);
            this.textBoxNom.TabIndex = 7;
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Location = new System.Drawing.Point(57, 7);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrenom.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(4, 135);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(36, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "Genre";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 172);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "Latéralité";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 101);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Classe";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 65);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Age";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Nom";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Prénom";
            // 
            // buttonAjoutBDD
            // 
            this.buttonAjoutBDD.Location = new System.Drawing.Point(40, 887);
            this.buttonAjoutBDD.Name = "buttonAjoutBDD";
            this.buttonAjoutBDD.Size = new System.Drawing.Size(177, 23);
            this.buttonAjoutBDD.TabIndex = 38;
            this.buttonAjoutBDD.Text = "Ajouter à la BDD";
            this.buttonAjoutBDD.UseVisualStyleBackColor = true;
            this.buttonAjoutBDD.Click += new System.EventHandler(this.buttonAjoutBDD_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1916, 983);
            this.Controls.Add(this.buttonAjoutBDD);
            this.Controls.Add(this.Données);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBoard);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picBoard)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Données.ResumeLayout(false);
            this.tabPageDonnees.ResumeLayout(false);
            this.tabPageDonnees.PerformLayout();
            this.tabPagePatient.ResumeLayout(false);
            this.tabPagePatient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoard;
        private System.Windows.Forms.TextBox TextBoxTempsPause;
        private System.Windows.Forms.TextBox textBoxTempsTrace;
        private System.Windows.Forms.TextBox textBoxLongTrace;
        private System.Windows.Forms.TextBox textBoxPression;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAltitude;
        private System.Windows.Forms.TextBox textBoxTwist;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAzimuth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxPrintNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxAverageSpeed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxLettersHeight;
        private System.Windows.Forms.TextBox textBoxLettersWidth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPageDonnees;
        private System.Windows.Forms.TabPage tabPagePatient;
        public System.Windows.Forms.TabControl Données;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBoxClasse;
        private System.Windows.Forms.NumericUpDown numericUpDownAge;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxSymbole;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox comboBoxLateralite;
        private System.Windows.Forms.ComboBox comboBoxGenre;
        private System.Windows.Forms.Button buttonAjoutBDD;
    }
}