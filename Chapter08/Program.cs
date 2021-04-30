using System;
using System.Collections;

namespace Chapter08
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExampleClone();
            //ExampleInterfaceException();
            //ExampleInterfaceIs();
            //ExampleInterfaceParameter();
            //ExampleReturnInterface();
            //ExampleManyInterfaces();
            //ExampleInterfaceHierarchy();
            //ExampleIEnumerable();
            //ExampleIClonebale();
            ExampleIComparable();

            Console.WriteLine("Hello World!");
        }

        static void ExampleClone()
        {
            string myStr = "Hello!";
            OperatingSystem unixOS = new OperatingSystem(PlatformID.Unix, new Version());
            //System.Data.SqlClient.SqlConnection sqlCon = new System.Data.SqlClient.SqlConnection();
            CloneMe(myStr);
            CloneMe(unixOS);
        }

        private static void CloneMe(ICloneable c)
        {
            object theClone = c.Clone();
            Console.WriteLine($"Your clone is a: {theClone.GetType().Name}");
        }

        static void ExampleInterfaceException()
        {
            Circle c = new Circle("Lisa");
            IPointy itfPt = null;
            try
            {
                itfPt = (IPointy)c;
                Console.WriteLine(itfPt.Points);
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            Hexagon hex = new Hexagon("Peter");
            IPointy itfPt2 = hex as IPointy;
            if (itfPt2 != null)
            {
                Console.WriteLine($"Points: {itfPt2.Points}");
            }
            else
            {
                Console.WriteLine("OOPS! Not pointy...");
            }
        }

        static void ExampleInterfaceIs()
        {
            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo") };
            for (int i = 0; i < myShapes.Length; i++)
            {
                myShapes[i].Draw();
                if (myShapes[i] is IPointy ip)
                {
                    Console.WriteLine($"-> Points: {ip.Points}");
                }
                else
                {
                    Console.WriteLine($"-> {myShapes[i].PetName}\'s not pointy!");
                }
            }
        }

        /// <summary>
        /// метод, принимающий интерфейс
        /// </summary>
        /// <param name="itf3d"></param>
        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }

        static void ExampleInterfaceParameter()
        {
            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo") };
            for (int i = 0; i < myShapes.Length; i++)
            {
                if (myShapes[i] is IDraw3D)
                {
                    DrawIn3D((IDraw3D)myShapes[i]);
                }
            }
        }

        /// <summary>
        /// метод, возвращающий интерфейс
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach (var s in shapes)
            {
                if (s is IPointy ip)
                {
                    return ip;
                }
            }
            return null;
        }

        static void ExampleReturnInterface()
        {
            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("JoJo") };
            IPointy firstPointyItem = FindFirstPointyShape(myShapes);
            Console.WriteLine($"The item has {firstPointyItem.Points} points");
        }

        static void ExampleManyInterfaces()
        {
            Octagon oct = new Octagon();
            IDrawToForm itfForm = (IDrawToForm)oct;
            itfForm.Draw();

            ((IDrawToPrinter)oct).Draw();

            if (oct is IDrawToMemory dtm)
            {
                dtm.Draw();
            }
            
        }

        static void ExampleInterfaceHierarchy()
        {
            BitmapImage myBitmap = new BitmapImage();
            myBitmap.Draw();
            myBitmap.DrawInBoundingBox(10, 10, 10, 10);
            myBitmap.DrawUpsideDown();

            IAdvancedDraw iAdvDraw = myBitmap as IAdvancedDraw;
            if (iAdvDraw != null)
            {
                iAdvDraw.DrawUpsideDown();
            }
        }

        static void ExampleIEnumerable()
        {
            Garage carLot = new Garage();

            IEnumerator carEnumerator = carLot.GetEnumerator();

            foreach (Car c in carLot)
            {
                Console.WriteLine($"{c.PetName} is going {c.CurrentSpeed} MPH");
            }
        }

        static void ExampleIClonebale()
        {
            Point p1 = new Point(100, 100, "Jane");
            Point p2 = (Point)p1.Clone();
            
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            p2.desc.PetName = "My new Point";
            p2.X = 9;
            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }

        static void ExampleIComparable()
        {
            Car[] carArray = new Car[5];
        
            carArray[0] = new Car("Rusty", 80,1);
            carArray[1] = new Car("Mary", 40, 234);
            carArray[2] = new Car("Viper", 40, 34);
            carArray[3] = new Car("Mel", 40,4);
            carArray[4] = new Car("Chucky", 40, 5);

            Array.Sort(carArray, new PetNameComparer());
            Array.Sort(carArray, Car.SortByPetName);

            foreach (var car in carArray)
            {
                Console.WriteLine($"{car.CarID}, {car.PetName}");
            }
        }
    }
}
