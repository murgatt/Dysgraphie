using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    class AverageSpeed : AbstractIndicator
    {
        public AverageSpeed(List<Point> points, Analysis analysis) : base(points, analysis)
        {}

        public override void calcul()
        {
            double som = 0, t = 0;
            Point pp1, p;
            for (int i = 0; i < this.points.Count-2; ++i)
            {
                pp1 = this.points.ElementAt(i + 1);
                p = this.points.ElementAt(i);
                if (p.id+1 == pp1.id)
                {
                    som += Math.Sqrt(Math.Pow(pp1.x- p.x, 2) + Math.Pow(pp1.y - p.y, 2));
                    t += (pp1.t - p.t);
                } 
            }
            this.analysis.averageSpeed = som / t;
        }
    }
}
