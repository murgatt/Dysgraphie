using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dysgraphie.Datas;

namespace Dysgraphie.Indicators
{
    abstract class AbstractIndicator
    {
        protected List<Point> points;
        protected Analysis analysis;

        public AbstractIndicator(List<Point> points, Analysis analysis)
        {
            this.points = points;
            this.analysis = analysis;
        }

        public abstract void calcul();

    }
}
