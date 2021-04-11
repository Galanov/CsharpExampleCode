using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06
{
    partial class Employee
    {
        //поля данных
        protected string empName;
        protected int empId;
        protected float currPay;
        protected int empAge;
        protected string empSSN;
        //protected BenefitPackage empBenefits = new BenefitPackage();

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

        class BenefitPackage
        {
            public double ComputePayDeduction()
            {
                return 125.0;
            }

            public enum BenefitPackageLevel
            {
                Standard,
                Gold,
                Platinum
            }
        }

        //public double GetBenefitCost()
        //{
        //    return empBenefits.ComputePayDeduction();
        //}

        //public BenefitPackage Benefits
        //{
        //    get { return empBenefits; }
        //    set { empBenefits = value; }
        //}
        
        //Этот метод может быть переопределен в производном классе
        public virtual void GiveBonus(float amount)
        {
            Pay += amount;
        }
    }
}
