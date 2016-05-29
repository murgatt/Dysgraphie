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

namespace Dysgraphie.Views
{
    public partial class Main : Form
    {
        private String state = "stopped";
        private System.Timers.Timer timer = new System.Timers.Timer(1000);
        private TimeSpan temps;
        private System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
        private Char[] characters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private List<char> sequence = new List<Char>();
        private int nbTxt = 0;
        private Child child;
        private Boolean basicMode = true; 

        public Main()
        {
            InitializeComponent();
            timer.Elapsed += new ElapsedEventHandler(TimerIncrement);
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New n = new New();
            DialogResult result = n.ShowDialog();
            if(result == DialogResult.OK)
            {
                child = n.child;
                Init();
            }
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
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
            this.nameLabel.Text = child.name;
            this.forenameLabel.Text = child.forename;
            this.birthLabel.Text = child.birth.ToString();
            this.ageLabel.Text = child.age.ToString();
            this.gradeLabel.Text = child.grade;
            this.lateralityLabel.Text = child.laterality;
            this.genderLabel.Text = child.gender;
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
            if (nbTxt+1 <= sequence.Count)
            {
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
        }

        private void restart()
        {
            DialogResult restartResult = MessageBox.Show("Etes-vous sûr de vouloir recommencer ? Les tracés non sauvegardés seront supprimés.", "Recommencer ?", MessageBoxButtons.YesNo);
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
                this.timerLabel.Text = "00:00:00";
            }
        }

        
    }
}
