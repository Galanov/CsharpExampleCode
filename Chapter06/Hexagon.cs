using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06
{
    class Hexagon:Shape
    {
        public Hexagon() { }
        public Hexagon(string name)
            : base(name) { }

        public override void Draw()
        {
            Console.WriteLine("Drawing {0} the Hexagon", PetName);
        }
    }
}
