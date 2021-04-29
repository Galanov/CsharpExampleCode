using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    class Triangle : Shape, IPointy
    {
        public Triangle() { }
        public Triangle(string name)
            :base(name)
        { }
        public byte Points
        {
            get { return 3; }
        }

        public override void Draw()
        {
            Console.WriteLine($"Drawing {PetName} the Triangle");
        }

    }
}
