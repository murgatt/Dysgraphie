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
    public partial class GradeSelector : Form
    {
        public String initGrade { get; set; }
        public String grade { get; set; }

        public GradeSelector(String initGrade)
        {
            this.initGrade = initGrade;
            this.grade = initGrade;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grade = this.comboBox1.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.comboBox1.Enabled = false;
                grade = initGrade;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                this.comboBox1.Enabled = true;
                this.comboBox1.SelectedItem = grade;
                grade = this.comboBox1.Text;
            }
        }
    }
}
