using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter05
{
    class MyMathClass
    {
        //Поля только для чтения могут присваиваться 
        //в конструкторах, но больше нигде
        public readonly double PI2;
        public const double PI = 3.14;
        public static readonly double PI3 = 3.14;

        public MyMathClass()
        {
            PI2 = 3.14;
        }
    }

    static class ConstData
    {
        static void Example()
        {

        }
    }
}
