using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dysgraphie.Views
{
    // Popup selecteur de classe 
    public partial class GradeSelector : Form
    {
        public String initGrade { get; set; } // Classe par défaut
        public String grade { get; set; } // Classe choisie

        // Constructeur qui initialise avec une classe par défaut passée en paramètre
        public GradeSelector(String initGrade)
        {
            this.initGrade = initGrade;
            this.grade = initGrade;
            InitializeComponent();
        }

        // Handler de la combobox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grade = this.comboBox1.Text; // Mettre à jour la classe
        }

        // Handler du premier radio button
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // On met à jour la vue et la classe
            if (this.radioButton1.Checked)
            {
                this.comboBox1.Enabled = false;
                grade = initGrade;
            }
        }

        // Handler du second radio button
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // On met à jour la vue et la classe
            if (this.radioButton2.Checked)
            {
                this.comboBox1.Enabled = true;
                this.comboBox1.SelectedItem = grade;
                grade = this.comboBox1.Text;
            }
        }
    }
}
