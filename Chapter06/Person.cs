using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06
{
    class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string SSN { get; set; } = "";

        public Person(string fname, string lname, int personAge)
        {
            FirstName = fname;
            LastName = lname;
            Age = personAge;
        }

        public Person() { }

        public override string ToString()
        {
            return $"[First Name:{FirstName}; Last Name:{LastName}; Age:{Age}]";
        }

        public override bool Equals(object obj)
        {
            if (obj is Person && obj != null)
            {
                Person temp;
                temp = (Person)obj;
                if (temp.FirstName == this.FirstName
                    && temp.LastName == this.LastName
                    && temp.Age == this.Age)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            //return SSN.GetHashCode();
            return this.ToString().GetHashCode();
        }
    }
}
