using System;

namespace ExampleFromBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DefaultDeclarations();
        }

        //литерал default
        static void DefaultDeclarations()
        {
            int myInt = default;
            Console.WriteLine($"default int: {myInt}");
        }

        //Внутренние типы данных и оператор new
        static void NewingDataTypes ()
        {
            Console.WriteLine("=> Using new to create variables:");
            bool b = new bool(); // Устанавливается в false.

            int i = new int () ; // Устанавливается в 0.
            double d = new double(); // Устанавливается в 0.
            DateTime dt = new DateTime(); // Устанавливается в 1/1/0001 12:00:00 AM
            Console.WriteLine("{0}, {1}, {2}, { 3}", b, i, d, dt);
            Console.WriteLine();
        }

        //Члены System.Char
        static void CharFunctionality()
        {
            Console.WriteLine("=> char type Functionality:");
            char myChar = 'a';
            Console.WriteLine("char.IsDigit ('a') : {0}", char.IsDigit(myChar));
            Console.WriteLine("char.IsLetter ('a’) : {0}", char.IsLetter(myChar));
            Console.WriteLine("char.IsWhiteSpace('Hello There’, 5): {0}",
            char.IsWhiteSpace("Hello There", 5));
            Console.WriteLine("char.IsWhiteSpace('Hello There', 6): {0}",
            char.IsWhiteSpace("Hello There", 6));
            Console.WriteLine("char.IsPunctuation('?'): {0}",
            char.IsPunctuation('?'));
            Console.WriteLine();
        }


    }



}
