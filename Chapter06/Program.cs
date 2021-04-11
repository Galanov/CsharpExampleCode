using System;

namespace Chapter06
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreeDCircle o = new ThreeDCircle();
            o.Draw();

            ((Circle)o).Draw();
            Console.WriteLine("Hello World!");

            //ExampleAs();
            //CastingExamples();
            ExampleObjects();
            Console.ReadLine();
        }

        static void CastingExamples()
        {
            object frank = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);
            GivePromotion((Manager)frank);
            Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20000, "101-11-1321", 1);
            GivePromotion(moonUnit);
            SalesPerson jill = new PTSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            GivePromotion(jill);
        }

        static void GivePromotion(Employee emp)
        {
            Console.WriteLine("{0} was promoted!", emp.Name);
            //if (emp is SalesPerson s)
            //{
            //    Console.WriteLine("{0} made {1} sale(s)!", emp.Name, s.SalesNumber);//((SalesPerson)emp).SalesNumber);
            //    Console.WriteLine();
            //}
            //if (emp is Manager m)
            //{
            //    Console.WriteLine("{0} had {1} stock otions...", emp.Name, m.StockOptions);//((Manager)emp).StockOptions);
            //    Console.WriteLine();
            //}
            switch (emp)
            {
                case SalesPerson s when s.SalesNumber > 5:
                    Console.WriteLine("{0} made {1} sale(s)!", emp.Name, s.SalesNumber);//((SalesPerson)emp).SalesNumber);
                    break;
                case Manager m:
                    Console.WriteLine("{0} had {1} stock otions...", emp.Name, m.StockOptions);//((Manager)emp).StockOptions);
                    break;
                case null :
                    break;
            }
            Console.WriteLine();
        }

        static void ExampleObjects()
        {
            Person p1 = new Person("Homer", "Simpson", 50);
            Person p2 = new Person("Homer", "Simpson", 50);

            PrintPerson(p1, p2);
            p2.Age = 45;

            PrintPerson(p1, p2);
        }

        static void PrintPerson(Person p1, Person p2)
        {
            Console.WriteLine($"p1.ToString() = {p1.ToString()}");
            Console.WriteLine($"p2.ToString() = {p2.ToString()}");

            Console.WriteLine($"p1 = p2?:{p1.Equals(p2)}");

            Console.WriteLine($"Same hash codes: {p1.GetHashCode() == p2.GetHashCode()}");
        }

        static void ExampleAs()
        {
            object[] things = new object[4];
            things[0] = new Hexagon();
            things[1] = false;
            things[2] = new Manager("Frank Zappa", 9, 3000, 40000, "111-11-1111", 5);
            things[3] = "Last thing";

            foreach (var item in things)
            {
                Hexagon h = item as Hexagon;
                if (h == null)
                {
                    Console.WriteLine("Item is not a hexagon");
                }
                else
                {
                    h.Draw();
                }
            }
        }
    }
}
