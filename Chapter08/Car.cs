using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    class Car :IComparable
    {
        public const int MaxSpeed = 100;
        public int CarID { get; set; }

        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        private bool carIsDead;

        private Radio theMusicBox = new Radio();

        public Car() { }

        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public Car(string name, int speed, int id)
        {
            CurrentSpeed = speed;
            PetName = name;
            CarID = id;
        }

        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }

        public void Accelerate(int delta)
        {
            if (delta<0)
            {
                throw new ArgumentException("delta", "Speed must be greater than zero!");
            }
            if (carIsDead)
            {
                Console.WriteLine($"{PetName} is out of order...");
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
                    //Console.WriteLine($"{PetName} has overheated!");
                    CurrentSpeed = 0;
                    carIsDead = true;
                    //var ex = new Exception($"{PetName} has overheated!");
                    //var ex = new CarIsDeadException($"{PetName} has overheated!", "You have a lead foot", DateTime.Now);
                    //ex.HelpLink = "htttp://www.CarsRus.com";
                    //ex.Data.Add("TimeStamp", $"The car exploted at {DateTime.Now}");
                    //ex.Data.Add("Cause", "You habe a lead foot");
                    //throw ex;
                }
                else
                {
                    Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
                }
            }
        }

        public int CompareTo(object obj)
        {
            Car temp = obj as Car;
            if (temp != null)
            {
                //if (this.CarID > temp.CarID)
                //{
                //    return 1;
                //}
                //if (this.CarID < temp.CarID)
                //{
                //    return -1;
                //}
                //else
                //    return 0;
                return this.CarID.CompareTo(temp.CarID);
            }
            else
                throw new ArgumentException("Parameter is not a Car!");
        }

        public static IComparer SortByPetName
        {
            get
            {
                return (IComparer)new PetNameComparer();
            }
        }
    }
}
