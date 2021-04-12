using System;
using System.Collections;

namespace Chapter07
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleCar();
            Console.ReadLine();
        }

        static void ExampleCar()
        {
            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);
            try
            {
                //for (int i = 0; i < 10; i++)
                //{
                //    myCar.Accelerate(10);
                //}
                myCar.Accelerate(-10);
            }
            
            catch(CarIsDeadException e)
                when(e.ErrorTimeStamp.DayOfWeek != DayOfWeek.Friday)
            {
                //Console.WriteLine("\n ***Error! ***");
                //Console.WriteLine($"Member name: {e.TargetSite}");
                //Console.WriteLine($"Class defining member: {e.TargetSite.DeclaringType}");
                //Console.WriteLine($"Member type: {e.TargetSite.MemberType}");
                //Console.WriteLine($"Message: {e.Message}");
                //Console.WriteLine($"Source: {e.Source}");
                //Console.WriteLine($"Srack {e.StackTrace}");
                //Console.WriteLine("*** Out of exception logic ***");
                //Console.WriteLine($"Help Link: {e.HelpLink}");
                //foreach (DictionaryEntry de in e.Data)
                //{
                //    Console.WriteLine($"-> {de.Key}, {de.Value}");
                //}

                Console.WriteLine($" {e.Message}");
                Console.WriteLine($" {e.ErrorTimeStamp}");
                Console.WriteLine($" {e.CauseOfError}");
                throw;
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myCar.CrankTunes(false);
            }
        }
    }
}
