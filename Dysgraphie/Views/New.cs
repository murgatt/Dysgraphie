﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Dysgraphie.Database;

namespace Dysgraphie.Views
{
    // Vue pour la création d'un nouveau test
    public partial class New : Form
    {
        private String name;
        private String forename;
        private DateTime birth;
        private String grade;
        private String laterality;
        private String gender;
        public String path { get; set; }
        public Child child { get; set; }

        public New()
        {
            InitializeComponent();
        }

        // Handler bouton parcourir : ouvrir une dialog
        private void browsBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pathInput.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        // Handler du bouton annuler, on ferme
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Handler de tous les input de la vue, on valide ou non les infos
        private void input_Changed(object sender, EventArgs e)
        {
            if (this.nameInput.Text != "" && this.forenameInput.Text != "" && this.gradeSelect.Text != "" && this.pathInput.Text != "" && (this.leftRadioBtn.Checked || this.rightRadioBtn.Checked) && (this.girlRadioBtn.Checked || this.boyRadioBtn.Checked))
            {
                this.validateBtn.Enabled = true;
            }
            else
            {
                this.validateBtn.Enabled = false;
            }
        }

        // Handler du bouton valider, on créer l'enfant avec les données qui vont bien
        private void validateBtn_Click(object sender, EventArgs e)
        {
            name = this.nameInput.Text;
            forename = this.forenameInput.Text;
            birth = this.birthInput.Value;
            grade = this.gradeSelect.Text;
            if (this.leftRadioBtn.Checked)
            {
                laterality = "Gaucher";
            }
            else
            {
                laterality = "Droitier";
            }
            if (this.girlRadioBtn.Checked)
            {
                gender = "F";
            }
            else
            {
                gender = "M";
            }

            child = new Child(name, forename, birth, grade, laterality, gender);           
            
            path = this.pathInput.Text;
            String date = DateTime.Today.ToString("dd-MM-yyyy");
            String folderName = name + forename + "_" + date;
            path = path + "\\" + folderName;
            var folder = Directory.CreateDirectory(path);
            this.Close();
        }
    }
}
