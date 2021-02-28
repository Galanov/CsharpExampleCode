using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter05
{
    class Car
    {
        public string petName;
        public int currSpeed;

        public Car()
        {
            petName = "Chuck";
            currSpeed = 10;
        }

        public Car(string pn, int cs)
        {
            petName = pn;
            currSpeed = cs;
        }

        public Car(string pn) => petName = pn;

        public void PrintState()
            => Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);

        public void SpeedUp(int delta)
            => currSpeed += delta;
    }
}
