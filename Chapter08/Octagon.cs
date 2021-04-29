using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        void IDrawToForm.Draw()
        {
            Console.WriteLine("Drawing to form...");
        }

        void IDrawToMemory.Draw()
        {
            Console.WriteLine("Drawing to form...");
        }

        void IDrawToPrinter.Draw()
        {
            Console.WriteLine("Drawing to form...");
        }
    }
}
