using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter05
{
    enum PointColor
    {
        LightBlue,
        BloodRed,
        Gold
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public PointColor Color { get; set; }

        public Point (int xVal, int yVal)
        {
            X = xVal;
            Y = yVal;
            Color = PointColor.Gold;
        }

        public Point(PointColor ptColor)
        {
            Color = ptColor;
        }

        public Point() 
            :this(PointColor.BloodRed){ }

        public void DisplayStats()
        {
            Console.WriteLine("[{0}, {1}", X, Y);
        }
       
    }

    class ExamplePoint
    {
        static void Example1()
        {
            Point firstPoint = new Point();
            firstPoint.X = 10;
            firstPoint.Y = 10;
            firstPoint.DisplayStats();

            Point anotherPoint = new Point(20, 20);
            anotherPoint.DisplayStats();

            Point finalPoint = new Point() { X = 30, Y = 30 };
            finalPoint.DisplayStats();

            Point goldPoint = new Point(PointColor.Gold) { X = 90, Y = 20 };
        }
    }
}
