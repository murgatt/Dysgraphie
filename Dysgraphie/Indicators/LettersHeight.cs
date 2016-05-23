using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    class LettersHeight : AbstractIndicator
    {
        //Hauteur du caractère en cm
        public LettersHeight(List<Point> points, Analysis analysis) : base(points, analysis) { }


        public override void calcul()
        {
            Point max, min, p;
            if (points.Count > 0)
            {
                max = points.ElementAt(0);
                min = points.ElementAt(0);
                for (int i = 0; i < points.Count; ++i)
                {
                    p = points.ElementAt(i);
                    if (max.y < p.y)
                    {
                        max = p;
                    }
                    if (min.y > p.y)
                    {
                        min = p;
                    }
                }
                this.analysis.lettersHeight = (Convert.ToDouble(max.y) - Convert.ToDouble(min.y))/2000;
            }
        }
    }
}
