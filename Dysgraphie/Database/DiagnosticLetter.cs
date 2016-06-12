using Dysgraphie.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Database
{
    //Classe permettant le diagnostic d'une personne sur une lettre
    class DiagnosticLetter
    {
        private DbManager manager;
        private Analysis analysis;

        private Child patient;

         

        public DiagnosticDatas averageSpeed { get; set; }
        public DiagnosticDatas drawTime { get; set; }
        public DiagnosticDatas breakTime { get; set; }
        public DiagnosticDatas drawLength { get; set; }
        public DiagnosticDatas lettersHeight { get; set; }
        public DiagnosticDatas lettersWidth { get; set; }
        public DiagnosticDatas printNumber { get; set; }
        public DiagnosticDatas averagePression { get; set; }
        public DiagnosticDatas averageAltitude { get; set; }
        public DiagnosticDatas averageAzimuth { get; set; }
        public DiagnosticDatas averageTwist { get; set; }

        public char character { get; set; }

        public DiagnosticLetter(DbManager manager, Analysis analysis, char c, Child patient, string grade)
        {
            this.patient = patient;
            this.manager = manager;
            this.analysis = analysis;
            this.character = c;

            averageSpeed= new DiagnosticDatas();
            drawTime= new DiagnosticDatas();
            breakTime= new DiagnosticDatas();
            drawLength= new DiagnosticDatas();
            lettersHeight= new DiagnosticDatas();
            lettersWidth= new DiagnosticDatas();
            printNumber= new DiagnosticDatas();
            averagePression= new DiagnosticDatas();
            averageAltitude= new DiagnosticDatas();
            averageAzimuth= new DiagnosticDatas();
            averageTwist= new DiagnosticDatas();

            this.calcul(grade);

            this.TwoStandardDeviationFromMean(averageSpeed);
            this.TwoStandardDeviationFromMean(drawTime);
            this.TwoStandardDeviationFromMean(breakTime);
            this.TwoStandardDeviationFromMean(drawLength);
            this.TwoStandardDeviationFromMean(lettersHeight);
            this.TwoStandardDeviationFromMean(lettersWidth);
            this.TwoStandardDeviationFromMean(printNumber);
            this.TwoStandardDeviationFromMean(averagePression);
            this.TwoStandardDeviationFromMean(averageAltitude);
            this.TwoStandardDeviationFromMean(averageAzimuth);
            this.TwoStandardDeviationFromMean(averageTwist);

        }

        //Calcul le diagnostic de chacun des critères     
        public void calcul(String grade = null)
        {
            String query;
            if (grade == null)
            {
                query = "SELECT * FROM Datas, Children WHERE Children.ID = Datas.ChildID AND Symbole ='" + this.character + "' AND Classe = '" + this.patient.GetClasse() + "'";
            } else {
                query = "SELECT * FROM Datas, Children WHERE Children.ID = Datas.ChildID AND Symbole ='" + this.character + "' AND Classe = '" + grade + "'";
            }

            

            averageSpeed.mean = StatTools.mean(this.manager, query, "VitesseMoyenne");
            averageSpeed.standardDeviation = StatTools.standardDeviation(manager, query, "VitesseMoyenne");
            averageSpeed.testValue = analysis.averageSpeed;

            drawTime.mean = StatTools.mean(this.manager, query, "TempsTrace");
            drawTime.standardDeviation = StatTools.standardDeviation(manager, query, "TempsTrace");
            drawTime.testValue = analysis.drawTime;

            breakTime.mean = StatTools.mean(this.manager, query, "TempsPause");
            breakTime.standardDeviation = StatTools.standardDeviation(manager, query, "TempsPause");
            breakTime.testValue = analysis.breakTime;

            drawLength.mean = StatTools.mean(this.manager, query, "LongueurTrace");
            drawLength.standardDeviation = StatTools.standardDeviation(manager, query, "LongueurTrace");
            drawLength.testValue = analysis.drawLength;

            lettersHeight.mean = StatTools.mean(this.manager, query, "HauteurLettre");
            lettersHeight.standardDeviation = StatTools.standardDeviation(manager, query, "HauteurLettre");
            lettersHeight.testValue = analysis.lettersHeight;

            lettersWidth.mean = StatTools.mean(this.manager, query, "LargeurLettre");
            lettersWidth.standardDeviation = StatTools.standardDeviation(manager, query, "LargeurLettre");
            lettersWidth.testValue = analysis.lettersWidth;

            printNumber.mean = StatTools.mean(this.manager, query, "NbBlocs");
            printNumber.standardDeviation = StatTools.standardDeviation(manager, query, "NbBlocs");
            printNumber.testValue = analysis.printNumber;

            averagePression.mean = StatTools.mean(this.manager, query, "PressionMoyenne");
            averagePression.standardDeviation = StatTools.standardDeviation(manager, query, "PressionMoyenne");
            averagePression.testValue = analysis.mean("p");

            averageAltitude.mean = StatTools.mean(this.manager, query, "AltitudeMoyenne");
            averageAltitude.standardDeviation = StatTools.standardDeviation(manager, query, "AltitudeMoyenne");
            averageAltitude.testValue = analysis.mean("alt");

            averageAzimuth.mean = StatTools.mean(this.manager, query, "AzimuthMoyen");
            averageAzimuth.standardDeviation = StatTools.standardDeviation(manager, query, "AzimuthMoyen");
            averageAzimuth.testValue = analysis.mean("azi");

            averageTwist.mean = StatTools.mean(this.manager, query, "TwistMoyen");
            averageTwist.standardDeviation = StatTools.standardDeviation(manager, query, "TwistMoyen");
            averageTwist.testValue = analysis.mean("twi");
        }
    
        //Etablit la diagnostic (critère réussi, si la valeur se trouve à + ou - deux écart-type à la moyenne des valeur contenues dans la base de données)
        public void TwoStandardDeviationFromMean(DiagnosticDatas dd)
        {
            if(dd.testValue> dd.mean + 2 * dd.standardDeviation || dd.testValue < dd.mean - 2 * dd.standardDeviation) dd.OK = false;
            else dd.OK = true;
        }


        public String toString()
        {
            String str = "";
            str += "Vitesse Moyenne : " + this.averageSpeed.toString()+"\n";
            str += "Tenps de tracé : " + this.drawTime.toString() + "\n";
            str += "Temps de pause : " + this.breakTime.toString() + "\n";
            str += "Longueur de tracé: " + this.drawLength.toString() + "\n";
            str += "Hauteur de lettre: " + this.lettersHeight.toString() + "\n";
            str += "Largeur de lettre: " + this.lettersWidth.toString() + "\n";
            str += "Nombre de blocs: " + this.printNumber.toString() + "\n";
            str += "Pression moyenne: " + this.averagePression.toString() + "\n";
            str += "Altitude moyen: " + this.averageAltitude.toString() + "\n";
            str += "Azimuth moyen: " + this.averageAzimuth.toString() + "\n";
            str += "averageTwist: " + this.averageTwist.toString() + "\n";

            return str;
        }



        
    }
}

