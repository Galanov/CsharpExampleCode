using System;
using System.Text;

namespace ExampleFromBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ProcessBytes();
        }

        //литерал default
        static void DefaultDeclarations()
        {
            int myInt = default;
            Console.WriteLine($"default int: {myInt}");
        }

        //Внутренние типы данных и оператор new
        static void NewingDataTypes()
        {
            Console.WriteLine("=> Using new to create variables:");
            bool b = new bool(); // Устанавливается в false.

            int i = new int(); // Устанавливается в 0.
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

        //Строки и равенство
        static void StringEquality()
        {
            Console.WriteLine("=> String equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();
            // Проверить строки на равенство.
            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo.Equals(s2): {0}", "Yo!".Equals(s2));
            Console.WriteLine();

        }

        static void StringsAreImmutable()
        {
            // Установить начальное значение для строки,
            string s1 = "This is my string.";
            Console.WriteLine("s1 = {0}", s1);
            // Преобразована ли строка s1 в верхний регистр?
            string upperstring = s1.ToUpper();
            Console.WriteLine("upperString = {0}", upperstring);
            // Нет! Строка s1 осталась в том же виде!
            Console.WriteLine("s1 = {0}", s1);
        }

        ///Тип System.Text.StringBuilder
        static void FunWithStnngBuilder()
        {
            Console.WriteLine("=> Using the StringBuilder:");
            StringBuilder sb = new StringBuilder("**** Fantastic Games ****");
            sb.Append("\n");
            sb.AppendLine("Half Life");
            sb.AppendLine("Morrowind");
            sb.AppendLine("Deus Ex" + "2");
            sb.AppendLine("System Shock");
            Console.WriteLine(sb.ToString());
            sb.Replace("2", " Invisible War");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars.", sb.Length);
            Console.WriteLine();
        }

        //Интерполяция строк
        static void Stringlnterpolation()
        {
            // Некоторые локальные переменные будут включены в крупную строку.
            int age = 4;
            string name = "Soren";
            // Использование синтаксиса с фигурными скобками.
            string greeting = string.Format("Hello {0} you are {1} years old.", name, age);
            // Использование интерполяции строк.
            string greeting2 = $"Hello {name} you are {age} years old.";
        }

        //checked
        static void ProcessBytes()
        {
            byte b1 = 100;
            byte b2 = 250;
            //На этот раз сообщить компилятору о необходимости добавления
            // кода CIL, необходимого для генерации исключениях если возникает
            // переполнение или потеря значимости.
            try
            {
                checked
                {
                    byte sum = (byte)Add(b1, b2);
                    Console.WriteLine("sum = {0}", sum);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        static int Add(int х, int у)
        {
            return х + у;
        }

        //Оператор switch
        static void SwitchOnStnngExample()
        {
            Console.WriteLine("C# or VB");
            Console.Write("Please pick your language preference: ");
            string langChoice = Console.ReadLine();
            switch (langChoice)
            {
                case "C#":
                    Console.WriteLine("Good choice, C# is a fine language.");
                    break;
                case "VB":
                    Console.WriteLine("VB: OOP, multithreading and more!");
                    break;
                default:
                    Console.WriteLine("Well... good luck with that!");
                    break;
            }
        }
        static void ExecutePatternMatchingSwitch()
        {
            Console.WriteLine("1 [Integer (5)], 2 [String (\"Hi\")], 3 [Decimal(2.5)]");
            Console.Write("Please choose an option: ");
            string userChoice = Console.ReadLine();
            object choice;
            switch (userChoice)
            {
                case "1":
                    choice = 5;
                    break;
                case "2":
                    choice = "Hi";
                    break;
                case "3":
                    choice = 2.5;
                    break;
                default:
                    choice = 5;
                    break;
            }
            switch (choice)
            {
                case int i:
                    Console.WriteLine("Your choice is an integer {0}.", i);
                    // Выбрано целое число
                    break;
                case string s:
                    Console.WriteLine("Your choice is a string {0}.", s);
                    // Выбрана строка
                    break;
                case decimal d:
                    Console.WriteLine("Your choice is a decimal {0}.", d);
                    // Выбрано десятичное число
                    break;
                default:
                    Console.WriteLine("Your choice is something else.");
                    // Выбрано что-то другое
                    break;
            }
            Console.WriteLine();
        }

        static void ExecutePatternMatchingSwitchWithWhen()
        {
            Console.WriteLine("1 [C#], 2 [VB]");
            Console.Write("Please pick your language preference: ");
            object langChoice = Console.ReadLine();
            var choice = int.TryParse(langChoice.ToString(), out int c) ? c : langChoice;
            switch (choice)
            {
                case int i when i == 2:
                case string s when s.Equals("VB", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("VB: OOP, multithreading, and more!");
                    // VB: ООП, многопоточность и многое другое!
                    break;
                case int i when i == 1:
                case string s when s.Equals("C#", StringComparison.OrdinalIgnoreCase):
                    Console.WriteLine("Good choice, C# is a fine language.");
                    // Хороший выбор. C# - замечательный язык.
                    break;
                default:
                    Console.WriteLine("Well...good luck with that!");
                    // Хорошо, удачи с этим!
                    break;
            }
            Console.WriteLine();
        }
    }
}
