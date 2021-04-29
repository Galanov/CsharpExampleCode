using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    class BitmapImage : IAdvancedDraw
    {
        public void Draw()
        {
            Console.WriteLine("Drawwing...");
        }

        public void DrawInBoundingBox(int top, int left, int bottom, int right)
        {
            Console.WriteLine("Drawwing in a box...");
        }

        public void DrawUpsideDown()
        {
            Console.WriteLine("Drawwing upside down");
        }
    }
}
