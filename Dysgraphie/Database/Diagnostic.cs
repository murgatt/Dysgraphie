using Dysgraphie.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Database
{
    class Diagnostic
    {
        private DbManager manager;
        private Analysis analysis;

        private Child patient;

        private DiagnosticDatas vitesseMoyenne;
        private DiagnosticDatas tempsTrace;
        private DiagnosticDatas tempsPause;
        private DiagnosticDatas longueurTrace;
        private DiagnosticDatas hauteurLettre;
        private DiagnosticDatas largeurLettre;
        private DiagnosticDatas nbBlocs;
        private DiagnosticDatas pressionMoyenne;
        private DiagnosticDatas altitudeMoyenne;
        private DiagnosticDatas azimuthMoyen;
        private DiagnosticDatas twistMoyen;

        private char character;

        public Diagnostic(DbManager manager, Analysis analysis, char c, Child patient)
        {
            this.patient = patient;
            this.manager = manager;
            this.analysis = analysis;
            this.character = c;

            vitesseMoyenne= new DiagnosticDatas();
            tempsTrace= new DiagnosticDatas();
            tempsPause= new DiagnosticDatas();
            longueurTrace= new DiagnosticDatas();
            hauteurLettre= new DiagnosticDatas();
            largeurLettre= new DiagnosticDatas();
            nbBlocs= new DiagnosticDatas();
            pressionMoyenne= new DiagnosticDatas();
            altitudeMoyenne= new DiagnosticDatas();
            azimuthMoyen= new DiagnosticDatas();
            twistMoyen= new DiagnosticDatas();

            this.calcul();

            this.TwoStandardDeviationFromMean(vitesseMoyenne);
            this.TwoStandardDeviationFromMean(tempsTrace);
            this.TwoStandardDeviationFromMean(tempsPause);
            this.TwoStandardDeviationFromMean(longueurTrace);
            this.TwoStandardDeviationFromMean(hauteurLettre);
            this.TwoStandardDeviationFromMean(largeurLettre);
            this.TwoStandardDeviationFromMean(nbBlocs);
            this.TwoStandardDeviationFromMean(pressionMoyenne);
            this.TwoStandardDeviationFromMean(altitudeMoyenne);
            this.TwoStandardDeviationFromMean(azimuthMoyen);
            this.TwoStandardDeviationFromMean(twistMoyen);

        }

        public void calcul()
        {
            String query = "SELECT * FROM Datas, Children WHERE Children.ID = Datas.ChildID AND Symbole ='" + this.character + "' AND Lateralite = '" + this.patient.GetLateralite() + "'";

            vitesseMoyenne.mean = StatTools.mean(this.manager, query, "VitesseMoyenne");
            vitesseMoyenne.standardDeviation = StatTools.standardDeviation(manager, query, "VitesseMoyenne");
            vitesseMoyenne.testValue = analysis.averageSpeed;

            tempsTrace.mean = StatTools.mean(this.manager, query, "TempsTrace");
            tempsTrace.standardDeviation = StatTools.standardDeviation(manager, query, "TempsTrace");
            tempsTrace.testValue = analysis.drawTime;

            tempsPause.mean = StatTools.mean(this.manager, query, "TempsPause");
            tempsPause.standardDeviation = StatTools.standardDeviation(manager, query, "TempsPause");
            tempsPause.testValue = analysis.breakTime;

            longueurTrace.mean = StatTools.mean(this.manager, query, "LongueurTrace");
            longueurTrace.standardDeviation = StatTools.standardDeviation(manager, query, "LongueurTrace");
            longueurTrace.testValue = analysis.drawLength;

            hauteurLettre.mean = StatTools.mean(this.manager, query, "HauteurLettre");
            hauteurLettre.standardDeviation = StatTools.standardDeviation(manager, query, "HauteurLettre");
            hauteurLettre.testValue = analysis.lettersHeight;

            largeurLettre.mean = StatTools.mean(this.manager, query, "LargeurLettre");
            largeurLettre.standardDeviation = StatTools.standardDeviation(manager, query, "LargeurLettre");
            largeurLettre.testValue = analysis.lettersWidth;

            nbBlocs.mean = StatTools.mean(this.manager, query, "NbBlocs");
            nbBlocs.standardDeviation = StatTools.standardDeviation(manager, query, "NbBlocs");
            nbBlocs.testValue = analysis.printNumber;

            pressionMoyenne.mean = StatTools.mean(this.manager, query, "PressionMoyenne");
            pressionMoyenne.standardDeviation = StatTools.standardDeviation(manager, query, "PressionMoyenne");
            pressionMoyenne.testValue = analysis.mean("p");

            altitudeMoyenne.mean = StatTools.mean(this.manager, query, "AltitudeMoyenne");
            altitudeMoyenne.standardDeviation = StatTools.standardDeviation(manager, query, "AltitudeMoyenne");
            altitudeMoyenne.testValue = analysis.mean("alt");

            azimuthMoyen.mean = StatTools.mean(this.manager, query, "AzimuthMoyen");
            azimuthMoyen.standardDeviation = StatTools.standardDeviation(manager, query, "AzimuthMoyen");
            azimuthMoyen.testValue = analysis.mean("azi");

            twistMoyen.mean = StatTools.mean(this.manager, query, "TwistMoyen");
            twistMoyen.standardDeviation = StatTools.standardDeviation(manager, query, "TwistMoyen");
            twistMoyen.testValue = analysis.mean("twi");
        }
    

        public void TwoStandardDeviationFromMean(DiagnosticDatas dd)
        {
            if(dd.testValue> dd.mean + 2 * dd.standardDeviation || dd.testValue < dd.mean - 2 * dd.standardDeviation) dd.OK = false;
            else dd.OK = true;
        }


        public String toString()
        {
            String str = "";
            str += "Vitesse Moyenne : " + this.vitesseMoyenne.toString()+"\n";
            str += "Tenps de tracé : " + this.tempsTrace.toString() + "\n";
            str += "Temps de pause : " + this.tempsPause.toString() + "\n";
            str += "Longueur de tracé: " + this.longueurTrace.toString() + "\n";
            str += "Hauteur de lettre: " + this.hauteurLettre.toString() + "\n";
            str += "Largeur de lettre: " + this.largeurLettre.toString() + "\n";
            str += "Nombre de blocs: " + this.nbBlocs.toString() + "\n";
            str += "Pression moyenne: " + this.pressionMoyenne.toString() + "\n";
            str += "Altitude moyen: " + this.altitudeMoyenne.toString() + "\n";
            str += "Azimuth moyen: " + this.azimuthMoyen.toString() + "\n";
            str += "Twistmoyen: " + this.twistMoyen.toString() + "\n";

            return str;
        }



        
    }
}

