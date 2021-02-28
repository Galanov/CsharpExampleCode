using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter05
{
    partial class Employee
    {
        //поля данных
        private string empName;
        private int empId;
        private float currPay;
        private int empAge;
        private string empSSN;

        public Employee() { }
        public Employee(string name, int id, float pay)
            :this(name, 0, id, pay, null)
        {}

        public Employee(string name, int age, int id, float pay, string ssn)
        {
            Name = name;
            ID = id;
            Age = age;
            Pay = pay;
            empSSN = ssn;
        }

        
    }
}
