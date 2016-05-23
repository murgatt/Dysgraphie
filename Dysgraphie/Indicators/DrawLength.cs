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
        //Longueur de tracé en cm
        public DrawLength(List<Point> points, Analysis analysis) : base(points, analysis) {}


        public override void calcul()
        {
            double sum = 0;
            Point pp1, p;
            for (int i = 0; i < this.points.Count - 2; ++i)
            {
                pp1 = this.points.ElementAt(i + 1);
                p = this.points.ElementAt(i);
                if (p.id + 1 == pp1.id)
                {
                    sum += Math.Sqrt(Math.Pow(pp1.x- p.x, 2) + Math.Pow(pp1.y - p.y, 2));
                }
            }
            //convertion de points en cm
            sum = sum / 2000;
            this.analysis.drawLength = sum;
        }
    }
}
