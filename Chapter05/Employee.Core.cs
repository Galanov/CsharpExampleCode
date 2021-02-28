using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter05
{
    partial class Employee
    {
        public int Age
        {
            get { return empAge; }
            set { empAge = value; }
        }

        public string Name
        {
            get { return empName; }
            set
            {
                // Здесь value на самом деле имеет тип string,
                if (value.Length > 15)
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                // Ошибка! Длина имени превышает 15 символов!
                else
                    empName = value;
            }
        }

        public float Pay
        {
            get { return currPay; }
            set { currPay = value; }
        }

        public int ID // Обратите внимание на отсутствие круглых скобок.
        {
            get { return empId; }
            set { empId = value; }
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name : {0}", empName); // имя сотрудника
            Console.WriteLine("ID: {0}", empId); // идентификационный номер сотрудника
            Console.WriteLine("Age: {0}", empAge); // возраст сотрудника
            Console.WriteLine("Pay: {0}", currPay); // текущая выплата
        }
    }
}
