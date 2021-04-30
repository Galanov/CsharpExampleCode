using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    class PetNameComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            var car1 = x as Car;
            var car2 = y as Car;
            if (car1 != null && car2 != null)
            {
                return String.Compare(car1.PetName, car2.PetName);
            }
            else
            {
                throw new ArgumentException("Parameter is not Car");
            }
        }
    }
}
