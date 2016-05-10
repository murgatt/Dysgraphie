using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    class DrawLength : AbstractIndicator
    {

        public DrawLength(List<Point> points, Analysis analysis) : base(points, analysis) {}


        public override void calcul()
        {
            double som = 0;
            Point pp1, p;
            for (int i = 0; i < this.points.Count - 2; ++i)
            {
                pp1 = this.points.ElementAt(i + 1);
                p = this.points.ElementAt(i);
                if (p.id + 1 == pp1.id)
                {
                    som += Math.Sqrt(Math.Pow(pp1.x, 2) + Math.Pow(p.x, 2));
                }
            }
            this.analysis.drawLength = som;
        }
    }
}
