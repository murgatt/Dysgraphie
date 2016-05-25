using Dysgraphie.Indicators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Database
{
    class ChildDatas
    {
        private int childID;
        private char symbole;
        private double vitesseMoyenne;
        private double tempsTrace;
        private double tempsPause;
        private double longueurTrace;
        private double hauteurLettre;
        private double largeurLettre;
        private int nbBlocs;
        private double pressionMoyenne;
        private double altitudeMoyenne;
        private double azimuthMoyen;
        private double twistMoyen;

        public ChildDatas(int childID, char symbole, Analysis analyse)
        {
            this.childID = childID;
            this.symbole = symbole;
            this.vitesseMoyenne = analyse.averageSpeed;
            this.tempsTrace = analyse.drawTime;
            this.tempsPause = analyse.breakTime;
            this.longueurTrace = analyse.drawLength;
            this.hauteurLettre = analyse.lettersHeight;
            this.largeurLettre = analyse.lettersWidth;
            this.nbBlocs = analyse.printNumber;
            this.pressionMoyenne = analyse.mean("p");
            this.altitudeMoyenne = analyse.mean("alt");
            this.azimuthMoyen = analyse.mean("azi");
            this.twistMoyen = analyse.mean("twi");
        }
        

        public void saveDatas(DbManager manager)
        {
            string req = "Insert into Datas values ('" + this.childID + "','" + this.symbole+ "','" + this.vitesseMoyenne+ "','" + this.tempsTrace+ "','" + this.tempsPause+ "','" + this.longueurTrace+ "','" + this.hauteurLettre+ "','" + this.largeurLettre+ "','" + this.nbBlocs + "','"+ this.pressionMoyenne + "','" + this.altitudeMoyenne + "','" + this.azimuthMoyen + "','" + this.twistMoyen + "' );";
            manager.DBConnexion();
            manager.QueryRequest(req);
            manager.DBDeconnexion();
        }

    }
}
