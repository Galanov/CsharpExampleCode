using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    class Point :ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointDescription desc = new PointDescription();

        public Point() { }
        public Point(int xPos, int yPos)
        {
            X = xPos;
            Y = yPos;
        }

        public Point(int xPos, int yPos, string petName)
        {
            X = xPos;
            Y = yPos;
            desc.PetName = petName;
        }

        public override string ToString()
        {
            return $"X = {X}; Y = {Y}; Name = {desc.PetName}; \nID = {desc.PointID}";
        }

        public object Clone()
        {

            Point newPoint = (Point)this.MemberwiseClone();
            PointDescription currentDesc = new PointDescription();
            currentDesc.PetName = this.desc.PetName;
            newPoint.desc = currentDesc;
            return newPoint;
                
            //new Point(this.X, this.Y);
        }

        public struct PointT<T>
        {
            public T X { get; set; }
            public T Y { get; set; }

            //public PointDescription desc = new PointDescription();

            //public Point() { }
            public PointT(T xPos, T yPos)
            {
                X = xPos;
                Y = yPos;
            }

            //public Point(T xPos, T yPos, string petName)
            //{
            //    X = xPos;
            //    Y = yPos;
            //    desc.PetName = petName;
            //}

            public override string ToString()
            {
                return $"[{X}, {Y}]";
            }

            public void ResetPoint()
            {
                X = default(T) ;
                Y = default (T);
            }
        }
    }
}
