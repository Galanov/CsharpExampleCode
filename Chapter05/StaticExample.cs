using System;
using System.Collections.Generic;
using System.Text;


namespace Chapter05
{
    class StaticExample
    {
    }

    class SavingsAccount
    {
        public double currBalance;

        public static double currInterestRate = 0.04;

        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }

        static SavingsAccount()
        {
            currInterestRate = 0.04;
        }

        public static void SetInterestRate (double newRate)
        {
            currInterestRate = newRate;
        }

        public static double GetInterestRate()
        {
            return currInterestRate;
        }
    }

    static class TimeUtilClass
    {
        public static void PrintTime()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        public static void PrintDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        //public static void PnntTime() => WriteLine(Now.ToShortTimeStnng());
        //public static void PnntDate() => WnteLine(Today.ToShortDateStnng());
    }
}
