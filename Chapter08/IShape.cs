using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    interface IShape: IDrawable, IPrintable
    {
        int GetNumberOfSides();
    }
}
