using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter10.Models
{
    class Car
    {
        //1. Определить тип делегата.
        public delegate void CarEngineHandler(string msgForCaller);

        
        //2. Определить переменную-член этого типа делегата.
        private CarEngineHandler listOfHandlers;
        // 3. Добавить регистрационную функцию для вызывающего кода.
        //public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        //{
        //    listOfHandlers = methodToCall;
        //}

        // Добавление поддержки группового вызова.
        // Обратите внимание на использование операции +=,
        // а не обычной операции присваивания (=) .
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }

        // Данные состояния,
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // Исправен ли автомобиль?
        private bool carlsDead;
        // Конструкторы класса,
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        // 4. Реализовать метод Accelerate () для обращения к списку
        // вызовов делегата в подходящих обстоятельствах.
        public void Accelerate(int delta)
        {
            // Если этот автомобиль сломан, то отправить сообщение об этом,
            if (carlsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry, this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                // Автомобиль почти сломан?
                if (10 == (MaxSpeed - CurrentSpeed)
                    && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                    carlsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }
    }

    public class Car2
    {
        private bool carlsDead;
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;

        public delegate void CarEngineHandler(string msgForCaller);

        public CarEngineHandler listOfHandlers;

        public void Accelerate(int delata)
        {
            if (listOfHandlers != null)
            {
                listOfHandlers("Sorry, this car is dead...");
            }
        }
    }

    public class CarEvent
    {
        private bool carIsDead;
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }

        //public delegate void CarEngineHandler(string msg);
        public delegate void CarEngineHandler(object sender, CarEventArgs e);

        //public event CarEngineHandler Exploded;
        //public event CarEngineHandler AboutToBlow;

        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        public CarEvent(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                //if (Exploded != null)
                //{
                //    Exploded("Sorry, this car is dead...");
                //}
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));
            }
            else
            {
                CurrentSpeed += delta;
                if (10 == MaxSpeed - CurrentSpeed && AboutToBlow != null)
                {
                    AboutToBlow?.Invoke(this, new CarEventArgs( "Careful buddy! Gonna blow"));
                }
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }
    }
}

