using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    public interface IAdvancedDraw: IDrawable
    {
        void DrawInBoundingBox(int top, int left, int bottom, int right);
        void DrawUpsideDown();
    }
}
