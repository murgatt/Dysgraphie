using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dysgraphie.Drawing;

namespace Dysgraphie.Tools
{
    class CoordinateConverter
    {
        public struct ScreenPoint
        {
            public int X, Y;

            public ScreenPoint(int x, int y)
            {
                this.X = x; this.Y = y;
            }
        }

        static private int screenSizeX, screenSizeY;

        static void printPoint(ScreenPoint p, String msg)
        {
            Console.WriteLine(msg + "Point : " + p.X + ", " + p.Y);
        }

        static public ScreenPoint convertScreenToGraphic(ScreenPoint p, int objectPosX, int objectPosY, int objectSizeX, int objectSizeY)
        {
            ScreenPoint result = new ScreenPoint(0, 0);
            printPoint(p, "Before ");

            float ratioX = (float)objectSizeX / (float)screenSizeX;
            result.X = (int)(p.X * ratioX) + objectPosX;

            float ratioY = (float)objectSizeY / (float)screenSizeY;
            result.Y = (int)(p.Y * ratioY) + objectPosY;

            printPoint(result, "After ");
            return result;
        }
    }
}