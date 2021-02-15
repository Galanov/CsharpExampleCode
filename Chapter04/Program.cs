using System;

namespace Chapter04
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypeContainingRefType();
        }

        //Массив объектов
        static void ArrayOfObjects()
        {
            Console.WriteLine("=> Array of Objects.");
            // Массив объектов может содержать все что угодно,
            object[] myObjects = new object[4];
            myObjects[0] = 10;
            myObjects[1] = false;
            myObjects[2] = new DateTime(1969, 3, 24);
            myObjects[3] = "Form & Void";
            foreach (object obj in myObjects)
            {
                // Вывести тип и значение каждого элемента в массиве.
                Console.WriteLine("Туре: {0}, Value: {1}", obj.GetType(), obj);
            }
            Console.WriteLine();
        }

        //Зубчатый массив
        static void JaggedMultidimensionalArray()
        {
            Console.WriteLine("=> Jagged multidimensional array.");
            // Зубчатый многомерный массив (т.е. массив массивов).
            // Здесь мы имеем массив из 5 разных массивов,
            int[][] myJagArray = new int[5][];
            // Создать зубчатый массив.
            for (int i = 0; i < myJagArray.Length; i++)
                myJagArray[i] = new int[i + 7];
            // Вывести все строки (помните, что каждый элемент имеет стандартное значение 0).
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < myJagArray[i].Length; j++)
                    Console.Write(myJagArray[i][j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Возвращение множества выходных параметров,
        static void FillTheseValues(out int a, out string b, out bool c)
        {
            a = 9;
            b = "Enjoy your string.";
            c = true;
        }

        //Ссылочные локальные переменные и возвращаемые ссылочные значения (нововведения)
        public static ref string SampleRefReturn(string[] strArray, int position)
        {
            return ref strArray[position];
        }
        static void ExampleRef()
        {
            string[] stringArray = { "one", "two", "three" };
            int pos = 1;
            Console.WriteLine("=> Use Ref Return");
            Console.WriteLine("Before: {0}, {1}, {2} ", stringArray[0], stringArray[1], stringArray[2]);
            ref var refOutput = ref SampleRefReturn(stringArray, pos);
            refOutput = "new";
            Console.WriteLine("After: {0}, {1}, {2} ", stringArray[0],
            stringArray[1], stringArray[2]);
        }

        ///Типы значений, содержащие ссылочные типы
        class ShapeInfo
        {
            public string InfoString;
            public ShapeInfo(string info)
            {
                InfoString = info;
            }
        }
        struct Rectangle
        {
            // Структура Rectangle содержит член ссылочного типа,
            public ShapeInfo RectInfo;
            public int RectTop, RectLeft, RectBottom, RectRight;
            public Rectangle(string info, int top, int left, int bottom, int right)
            {
                RectInfo = new ShapeInfo(info);
                RectTop = top; RectBottom = bottom;
                RectLeft = left; RectRight = right;
            }
            public void Display()
            {
                Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, " +
                "Left = {3}, Right = {4}",
                RectInfo.InfoString, RectTop, RectBottom, RectLeft, RectRight);

            }
        }
        static void ValueTypeContainingRefType()
        {
            // Создать первую переменную Rectangle.
            Console.WriteLine("-> Creating rl");
            Rectangle rl = new Rectangle("First Rect", 10, 10, 50, 50);
            // Присвоить новой переменной Rectangle переменную rl.
            Console.WriteLine("-> Assigning r2 to rl");
            Rectangle r2 = rl;
            // Изменить некоторые значения в r2.
            Console.WriteLine("-> Changing values of r2");
            r2.RectInfo.InfoString = "This is new info!";
            r2.RectBottom = 4444;
            // Вывести значения из обеих переменных Rectangle,
            rl.Display();
            r2.Display();
        }
        
    }
}
