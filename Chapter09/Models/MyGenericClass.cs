using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter09.Models
{
    class MyGenericClass<T> where T :  class, IDrawable, new()
    {
    }

    class MyGenericClass2<K,T>
        where K : SomeBaseClass, new()
        where T : struct, IComparable<T>
    {
    }

    internal class SomeBaseClass
    {
    }
}
