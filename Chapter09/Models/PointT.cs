using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter09.Models
{
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
            X = default(T);
            Y = default(T);
        }
    }
}
