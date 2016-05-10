using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    class DrawTime : AbstractIndicator
    {

        public DrawTime(List<Point> points, Analysis analysis) : base(points, analysis) { }


        public override void calcul()
        {
            this.analysis.drawTime = this.points.ElementAt(this.points.Count - 1).t - this.points.ElementAt(0).t;
        }
    }
}
