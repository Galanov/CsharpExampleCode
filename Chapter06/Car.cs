﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06
{
    class Car
    {
        public readonly int maxSpeed;
        private int currSpeed;
        public Car(int max)
        {
            maxSpeed = max;
        }

        public Car()
        {
            maxSpeed = 55;
        }

        public int Speed
        {
            get { return currSpeed; }
            set 
            { 
                currSpeed = value;
                if (currSpeed > maxSpeed)
                {
                    currSpeed = maxSpeed;
                }
            }
        }
    }
}
