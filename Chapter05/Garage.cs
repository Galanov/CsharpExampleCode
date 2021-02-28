using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter05
{
    class Garage
    {
        //автоматические св-ва
        public int NumberOfCars { get; set; } = 1;

        //автоматические св-ва
        public Car MyAuto { get; set; } = new Car();

        public Garage()
        {
            //MyAuto = new Car();
            //NumberOfCars = 1;
        }

        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }
}
