using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter05
{
    class Motorcycle
    {
        public int driverIntensity;
        public string driverName;
        public Motorcycle() {
            Console.WriteLine("In default ctor");
        }

        public Motorcycle(int intensity)
            :this(intensity,"")
        {
            Console.WriteLine("In ctor taking an int");
        }

        public Motorcycle(string name)
            : this(0, name)
        {
            Console.WriteLine("In ctor taking a string");
        }

        public Motorcycle(int intensity, string name)
        {
            Console.WriteLine("In master ctor ");
            if (intensity > 10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
            driverName = name;
        }
        public void PopAWheely()
        {
            Console.WriteLine("Yeee Haew!");
        }

        public void SetDriverName(string name)
        {
            this.driverName = name;
        }

        public void SetIntensity(int intensity)
        {
            if (intensity>10)
            {
                intensity = 10;
            }
            driverIntensity = intensity;
        }
    }
}
