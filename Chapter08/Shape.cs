using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    abstract class Shape
    {
        public Shape(string name = "NoName")
        {
            PetName = name;
        }

        public string PetName { get; set; }

        //public virtual void Draw()
        //{
        //    Console.WriteLine("Inside Shape.Draw()");
        //}
        public abstract void Draw();
    }
}
