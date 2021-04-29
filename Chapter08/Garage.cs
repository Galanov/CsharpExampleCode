using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Chapter08
{
    class Garage: IEnumerable
    {
        private Car[] carArray = new Car[4];

        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return carArray.GetEnumerator();
        //}
        IEnumerator IEnumerable.GetEnumerator()
        {
            return carArray.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            throw new Exception("This won't get called");

            return actualImplementation();
        }

        IEnumerator actualImplementation()
        {
            foreach (var c in carArray)
            {
                yield return c;
            }
        }

        public IEnumerable GetTheCars(bool returnReversed)
        {
            return actualImplementation();

            IEnumerable actualImplementation()
            {
                if (returnReversed)
                {
                    for (int i = carArray.Length; i != 0; i--)
                    {
                        yield return carArray[i - 1];
                    }
                }
                else
                {
                    foreach (var c in carArray)
                    {
                        yield return c;
                    }
                }
            }
        }
    }
}
