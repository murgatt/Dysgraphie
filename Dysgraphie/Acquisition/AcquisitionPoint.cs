﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Dysgraphie.Datas;
using Dysgraphie.Indicators;

namespace Dysgraphie.Acquisition
{
    // Cette classe permet d'enregistrer la liste des points acquis
    class AcquisitionPoint
    {
        public Analysis analysis { get; set; }

        //Thread Properties
        private Thread thread;
        private static Object lockObject = new Object();
        private List<Point> synchronizedList;
        //private List<Point> ListComplete;

        //Nombre points par thread ====>   5 1 points
        private int drawSpeed;
        private long previousTime;
        private long pauseTime;

        public AcquisitionPoint()
        {
            //ListComplete = new List<Point>();
            lockObject = new Object();
            analysis = new Analysis();

            drawSpeed = 100;
            previousTime = 0;
            pauseTime = 20;
        }



        //Permet d'ajouter un point à la liste
        public void AddPoint(Point p)
        {
            analysis.addPoint(p);
            //Lock part for synchronizedList access
            lock (lockObject)
            {
                synchronizedList.Add(p);
            }
        }

        public void Start()
        {
            Reset();
            thread.IsBackground = true;
            thread.Start();
        }

        public void Reset()
        {
            // LIST
            if (synchronizedList == null)
            {
                synchronizedList = new List<Point>();

            }
            this.analysis = new Analysis();
            synchronizedList.Clear();

            // THREAD
            if (thread == null)
            {
                thread = new Thread(new ThreadStart(Calcul));
            }


        }
        private void Calcul()
        {

            // Tant que le thread n'est pas tué, on travaille
            //Console.WriteLine("Start thread...");
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(drawSpeed);

                
                if (synchronizedList.Count > 0)
                {
                    //Lock part for synchronizedList access
                    lock (lockObject)
                    {
                        Point[] copyList = new Point[synchronizedList.Count];
                        this.synchronizedList.CopyTo(copyList);
                        this.calculDonnees(copyList);
                        synchronizedList.Clear();
                    }
                }
                
            }
        }

        private void calculDonnees(Point[] copyList)
        {
            analysis.analyse();
        }
                
        public double getBreakTime()
        {
            return analysis.breakTime;
        }

        public double getDrawLength()
        {
            return analysis.drawLength;
        }

        public double getDrawTime()
        {
            return analysis.drawTime;
        }
        
        public int getNumberOfPrint()
        {
            return analysis.printNumber;
        }

        public double getAverageSpeed()
        {
            return analysis.averageSpeed;
        }

        public double getLettersHeight()
        {
            return analysis.lettersHeight;
        }

        public double getLettersWidth()
        {
            return analysis.lettersWidth;
        }



    }
}
