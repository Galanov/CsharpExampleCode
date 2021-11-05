using Chapter10.Models;
using System;
using System.Collections.Generic;

namespace Chapter10
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExampleDelegate();
            //ExampleNotificationDelegate();
            //ExanpleGenericDelegate();
            //ExampleAction();
            //ExamplePablicDelegate();
            //ExampleEvent();
            //AnonymusMethodExample();
            //AnonymousLocal();
            //TraditionalDelegateSyntax();
            //AnonymousMethodSyntax();
            //LambdsExpressionSyntax();
            //LambdaExample();
            CarEventLambda();
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

        static void CallWhenExploded(string msg)
        {
            Console.WriteLine(msg);
        }
        static void CallHereToo(string msg)
        {
            Console.WriteLine(msg);
        }
        static void ExamplePablicDelegate()
        {
            Car2 myCar = new Car2();
            myCar.listOfHandlers = new Car2.CarEngineHandler(CallWhenExploded);
            myCar.Accelerate(10);

            myCar.listOfHandlers = new Car2.CarEngineHandler(CallHereToo);
            myCar.Accelerate(10);

            myCar.listOfHandlers.Invoke("hee, hee, hee ...");

        }

        static void ExampleEvent()
        {
            CarEvent c1 = new CarEvent("SlugBug", 100, 10);
            //c1.AboutToBlow += new CarEvent.CarEngineHandler(CarIsAlmostDoomed);
            //c1.AboutToBlow += new CarEvent.CarEngineHandler(CarAboutToBlow);
            //упрощенная запись
            c1.AboutToBlow += CarAboutToBlow;
            //CarEvent.CarEngineHandler d = new CarEvent.CarEngineHandler(CarExploded);
            //c1.Exploded += d;

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            //c1.Exploded -= d;

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }

        static void CarAboutToBlow(object sender, CarEventArgs e)
        {
            if (sender is CarEvent)
            {
                CarEvent c = (CarEvent)sender;
                Console.WriteLine("Critical Message from {0}: {1}", c.PetName, e.msg);
            }
        }

        static void CarAboutToBlow(string msg)
        {
            Console.WriteLine(msg);
        }

        static void CarIsAlmostDoomed(string msg)
        {
            Console.WriteLine("=> Critical Message from car: {0}", msg);
        }

        static void CarExploded(string msg)
        {
            Console.WriteLine(msg);
        }

        static void AnonymusMethodExample()
        {
            CarEvent c1 = new CarEvent("SlugBug", 100, 10);
            c1.AboutToBlow += delegate {
                Console.WriteLine("Eek! Going to fast");

	};
            c1.AboutToBlow += delegate(object sender, CarEventArgs e ){
                Console.WriteLine("Mesage from Car {0}", e.msg);

	};
            c1.Exploded += delegate (object sender, CarEventArgs e){
                Console.WriteLine("Fatal Message from car: {0}", e.msg);

	};
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }

        static void AnonymousLocal()
        {
            int aboutToBlowCounter = 0;
            CarEvent c1 = new CarEvent("SlugBug", 100, 10);
            c1.AboutToBlow +=delegate {

                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
	};
            c1.AboutToBlow += delegate(object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("critical message from car: {0}", e.msg);
            };
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
            Console.WriteLine("aboutToBlow event was fired {0} times", aboutToBlowCounter);
        }

        static void TraditionalDelegateSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);
            Console.WriteLine("Here are your even numbers");
            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine($"{evenNumber}\t");
            }
        }

        static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }

        static void AnonymousMethodSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            List<int> evenNumbers = list.FindAll(delegate (int i) {
                return (i % 2) == 0;
             });
            Console.WriteLine("Here are your even numbers");
            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine($"{evenNumber}\t");
            }
        }

        static void LambdsExpressionSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            List<int> evenNumbers = list.FindAll(i =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                bool isEven = (i % 2) == 0;
                return isEven;
            });
            Console.WriteLine("Here are your even numbers");
            foreach (var evenNumber in evenNumbers)
            {
                Console.WriteLine($"{evenNumber}\t");
            }
        }
        delegate string VerySimpleDelegate();

        static void LambdaExample()
        {
            SimpleMathLambda m = new SimpleMathLambda();
            m.SetMathHandler((msg, result) =>
            {
                Console.WriteLine("Message: {0}, Result: {1}", msg, result);
            });

            m.Add(10, 10);

            VerySimpleDelegate d = new VerySimpleDelegate(() =>
            {
                return "Enjoy your string!";
            });

            Console.WriteLine(d());

        }

        static void CarEventLambda()
        {
            CarEvent c1 = new CarEvent("SlugBug", 100, 10);
            c1.AboutToBlow += (sender, e) => { Console.WriteLine(e.msg); };
            c1.Exploded += (sender, e) => { Console.WriteLine(e.msg); };
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }
    }
}
