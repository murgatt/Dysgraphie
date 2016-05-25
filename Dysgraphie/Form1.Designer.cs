using Dysgraphie.Database;
using Dysgraphie.OutputFiles;
namespace Dysgraphie
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";

            PdfManager pdf = new PdfManager("toto","../../");
            pdf.Create();
            pdf.AddDataChild(new Child(1, "gouttefarde", "david", 25, "cp", "male", "droitier"));
            pdf.AddFirstComment("Le patient zero est atteint de maladie chronique en faite tu vois il est plutot nul en plus il est roux");
            pdf.ClosePdf();
        }

        #endregion
    }
}

