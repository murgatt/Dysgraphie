using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    class BreakTime : AbstractIndicator
    {
        public BreakTime(List<Point> points, Analysis analysis) : base(points, analysis) {}

        public override void calcul()
        {
            Point pp1, p;
            double sum = 0;
            for (int i = 0; i < this.points.Count-2; ++i)
            {
                p = this.points.ElementAt(i);
                pp1 = this.points.ElementAt(i + 1);
                if(p.id+1 != pp1.id)
                {
                    sum += pp1.t - p.t;
                }
            }
            this.analysis.breakTime = sum;
        }
    }
}
