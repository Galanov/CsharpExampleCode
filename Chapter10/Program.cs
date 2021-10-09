using Chapter10.Models;
using System;

namespace Chapter10
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExampleDelegate();
            //ExampleNotificationDelegate();
            //ExanpleGenericDelegate();
            ExampleAction();
            Console.WriteLine("Hello World!");
        }

        public delegate int BinaryOp(int x, int y);

        static void ExampleDelegate()
        {
            BinaryOp b = new BinaryOp(SimpleMath.Add);
            Console.WriteLine($"10+10 is {b(10, 10)}");
            DisplayDelegateInfo(b);
        }

        static void DisplayDelegateInfo(Delegate delObj)
        {
            foreach (var d in delObj.GetInvocationList())
            {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
            }
        }

        static void ExampleNotificationDelegate()
        {
            // Создать объект Car.
            Car cl = new Car("SlugBug", 100, 10);
            // Сообщить объекту Car, какой метод вызывать,
            // когда он пожелает отправить сообщение.
            //cl.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            //cl.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent2));
            //Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            //cl.RegisterWithCarEngine(handler2);
            // Увеличить скорость (это инициирует события).

            cl.RegisterWithCarEngine(CallMeHere);

            Console.WriteLine("***** Speeding uр *****");
            for (int i = 0; i < 6; i++ )
                cl.Accelerate(20);
            // Отменить регистрацию простого имени метода.
            cl.UnRegisterWithCarEngine(CallMeHere);

            // Отменить регистрацию второго обработчика.
            //cl.UnRegisterWithCarEngine(handler2);
            // Сообщения в верхнем регистре больше не выводятся.
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
                cl.Accelerate(20);

            Console.ReadLine();
        }

        static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
        }

        public static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }

        static void CallMeHere(string msg)
        {
            Console.WriteLine("=>Message from Car:{0}", msg);
        }

        //Обобщенный делегат
        public delegate void MyGenericDelegate<T>(T arg);

        static void ExanpleGenericDelegate()
        {
            Console.WriteLine("*****Generic Delegates * ****\n");
            // Зарегистрировать цели.
            MyGenericDelegate<string> strTarget =
                new MyGenericDelegate<string>(StringTarget) ;
            strTarget("Some string data");
            MyGenericDelegate<int> intTarget =
                new MyGenericDelegate<int>(IntTarget);
            intTarget(9);
        }

        static void StringTarget(string arg)
        {
            Console.WriteLine("arg in uppercase is: {0}", arg.ToUpper());
        }
        static void IntTarget(int arg)
        {
            Console.WriteLine("++arg is: {0}", ++arg);
        }

        //Обобщенные делегаты Action<> и Func<>
        static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Установить цвет текста консоли.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }
            // Восстановить цвет.
            Console.ForegroundColor = previous;
        }

        static void ExampleAction()
        {
            // Использовать делегат ActionO для указания на DisplayMessage.
            Action<string, ConsoleColor, int> actionTarget =
            new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message", ConsoleColor.Yellow, 5);
        }

        static int Add(int x, int y) => x + y;

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }

        static void ExampleFunc()
        {
            //Func<int, int, int> funcTarget = new Func<int, int, int>(Add);
            Func<int, int, int> funcTarget = Add;
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine("40 + 40 = {0}", result);
            //Func<int, int, string> funcTarget2 = new Func<int, int, string>(SumToString);
            Func<int, int, string> funcTarget2 = SumToString;

            string sum = funcTarget2(90, 300);
            Console.WriteLine(sum);
        }
    }
}
