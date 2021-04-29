using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    class Square : IShape
    {
        void IPrintable.Draw()
        {

        }
        void IDrawable.Draw()
        {
            
        }

        public int GetNumberOfSides()
        {
            return 4;
        }

        public void Print()
        {
            
        }
    }
}
