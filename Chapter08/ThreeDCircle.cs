using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    class ThreeDCircle : Circle, IDraw3D
    {
        public void Draw3D()
        {
            Console.WriteLine("Drawing Circle in 3D!");
        }
    }
}
