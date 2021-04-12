using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter07
{
    class Car
    {
        public const int MaxSpeed = 100;

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
                    var ex = new CarIsDeadException($"{PetName} has overheated!", "You have a lead foot", DateTime.Now);
                    ex.HelpLink = "htttp://www.CarsRus.com";
                    ex.Data.Add("TimeStamp", $"The car exploted at {DateTime.Now}");
                    ex.Data.Add("Cause", "You habe a lead foot");
                    throw ex;
                }
                else
                {
                    Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
                }
            }
        }
    }
}
