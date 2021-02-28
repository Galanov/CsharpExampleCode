using System;

namespace Chapter05
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.petName = "Henry";
            myCar.currSpeed = 10;

            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }
            Console.ReadLine();

            Motorcycle mc = new Motorcycle();
            mc.PopAWheely();

            Motorcycle c = new Motorcycle(5);
            c.SetDriverName("Tiny" );
            c.PopAWheely();
            Console.WriteLine("Rider name is {0}", c.driverName); //вывод имени гонщика
            Console.ReadLine();

        }
    }
}
