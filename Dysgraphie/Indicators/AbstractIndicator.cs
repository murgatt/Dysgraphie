﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dysgraphie.Datas;

namespace Dysgraphie.Indicators
{
    //Modèle pour un critères
    abstract class AbstractIndicator
    {
        protected List<Point> points;
        protected Analysis analysis;

        public AbstractIndicator(List<Point> points, Analysis analysis)
        {
            this.points = points;
            this.analysis = analysis;
        }

        //Méthode permettant de calculer la valeur du critère, qui est stockée dans un attribut de la variable analysis
        public abstract void calcul();

    }
}
