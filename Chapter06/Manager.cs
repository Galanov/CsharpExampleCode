using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06
{
    class Manager: Employee
    {
        public Manager(string fullName, int age, int empId,
            float currPay, string ssn, int numbOfOpts)
            :base(fullName, age,empId,currPay,ssn)
        {
            StockOptions = numbOfOpts;
            //ID = empId;
            //Age = age;
            //Name = fullName;
            //Pay = currPay;
            //social
        }

        public int StockOptions { get; set; }

        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOptions += r.Next(500);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Number of Stock Options: {0}", StockOptions);
        }
    }
}
