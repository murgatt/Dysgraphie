﻿using Dysgraphie.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dysgraphie.Indicators
{
    //Représente une analyse (calcul des différents critères sur un tracé)
    class Analysis
    {
        private List<AbstractIndicator> indicators;

        public char character { get; set; }

        public List<Double> instantSpeed { get; set; }
        public List<Double> instantAcceleration { get; set; }
        public List<Double> instantJerk { get; set; }
        public double averageSpeed { get; set; }
        public double drawLength { get; set; }
        public double drawTime { get; set; }
        public double breakTime { get; set; }
        public int printNumber{ get; set; }
        public double lettersHeight { get; set; }
        public double lettersWidth { get; set; }
        public double averagePression { get; set; }
        public double averageAltitude{ get; set; }
        public double averageAzimuth { get; set; }
        public double averageTwist { get; set; }

        public List<Point> points{get; }
        protected List<Point> pointsOnDraw;
        protected List<Point> pointsOverDraw;

        public Analysis()
        {

            this.points = new List<Point>();
            this.indicators = new List<AbstractIndicator>();
            this.pointsOnDraw = new List<Point>();
            this.pointsOverDraw = new List<Point>();
           
            this.pointsOnDraw.Sort();
            this.pointsOverDraw.Sort();

            this.indicators.Add(new InstantSpeed(this.pointsOnDraw, this));
            this.indicators.Add(new InstantAcceleration(this.pointsOnDraw, this));
            this.indicators.Add(new InstantJerk(this.pointsOnDraw, this));
            this.indicators.Add(new AverageSpeed(this.pointsOnDraw, this));
            this.indicators.Add(new DrawLength(this.pointsOnDraw, this));
            this.indicators.Add(new DrawTime(this.pointsOnDraw, this));
            this.indicators.Add(new BreakTime(this.pointsOnDraw, this));
            this.indicators.Add(new PrintNumber(this.pointsOnDraw, this));
            this.indicators.Add(new LettersHeight(this.pointsOnDraw, this));
            this.indicators.Add(new LettersWidth(this.pointsOnDraw, this));
        }

        public void addPoint(Point p)
        {
            this.points.Add(p);
            if (p.z == 0)
            {
                this.pointsOnDraw.Add(p);
            }
            else {
                this.pointsOverDraw.Add(p);
            }
        }

        public void analyse()
        {
            foreach(AbstractIndicator i in this.indicators)
            {
                i.calcul();
            }

            averagePression = this.mean("p");
            averageAltitude = this.mean("alt");
            averageAzimuth = this.mean("azi");
            averageTwist = this.mean("twi");
        }

        public double mean(String propertyName)
        {
            Point[] pointsList = new Point[this.pointsOnDraw.Count];
            this.pointsOnDraw.CopyTo(pointsList);
            if (pointsList.Length == 0) return 0;
            int sum = 0;
            Type myType = typeof(Point);
            PropertyInfo myPropInfo = myType.GetProperty(propertyName);
            foreach (Point p in pointsList)
            {
                sum += Convert.ToInt32(myPropInfo.GetValue(p, null));
            }
            return sum / this.pointsOnDraw.Count;
        }
    }
}
