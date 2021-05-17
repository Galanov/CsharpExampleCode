using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Chapter09.Models
{
    class SortPeopleByAge : IComparer<Person>
    {
        public int Compare([AllowNull] Person firstPerson, [AllowNull] Person secondPerson)
        {
            if (firstPerson?.Age > secondPerson?.Age)
            {
                return 1;
            }
            if (firstPerson?.Age < secondPerson?.Age)
            { 
                return -1;
            }
            return 0;
        }
    }
}
