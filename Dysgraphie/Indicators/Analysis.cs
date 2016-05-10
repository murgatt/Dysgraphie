using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    class Analysis
    {
        private List<AbstractIndicator> indicators;

        public List<Double> instantSpeed { get; set; }
        public double averageSpeed { get; set; }
        public double drawLength { get; set; }
        public double drawTime { get; set; }
        public double breakTime { get; set; }

        protected List<Point> points;
        protected List<Point> pointsOnDraw;
        protected List<Point> pointsOverDraw;

        public Analysis(List<Point> points)
        {
            this.points = points;
            this.indicators = new List<AbstractIndicator>();
            this.pointsOnDraw = new List<Point>();
            this.pointsOverDraw = new List<Point>();
            foreach(Point p in this.points)
            {
                if(p.z == 0)
                {
                    this.pointsOnDraw.Add(p);
                } else {
                    this.pointsOverDraw.Add(p);
                }
            }
            this.pointsOnDraw.Sort();
            this.pointsOverDraw.Sort();

            this.indicators.Add(new InstantSpeed(this.pointsOnDraw, this));
            this.indicators.Add(new AverageSpeed(this.pointsOnDraw, this));
            this.indicators.Add(new DrawLength(this.pointsOnDraw, this));
            this.indicators.Add(new DrawTime(this.pointsOnDraw, this));
            this.indicators.Add(new BreakTime(this.pointsOverDraw, this));
        }

        public void analyse()
        {
            foreach(AbstractIndicator i in this.indicators)
            {
                i.calcul();
            }
        }
    }
}
