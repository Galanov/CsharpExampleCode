using Chapter09.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Chapter09
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExampleArrayList();
            //WorkWithArrayList();
            //UseGenericStack();
            //UseGenericQueue();
            //UseSortedSet();
            ObservableCollectionExample();
            Console.WriteLine("Hello World!");
        }

        static void ExampleArrayList()
        {
            ArrayList strArray = new ArrayList();
            strArray.AddRange(new string[] { "First", "Second", "Third" });
            // Отобразить количество элементов в ArrayList.
            Console.WriteLine("This collection has {0} items.", strArray.Count);
            Console.WriteLine();
            // Добавить новый элемент и отобразить текущее их количество.
            strArray.Add("Fourth!");
            Console.WriteLine("This collection has {0} items.", strArray.Count);
            // Отобразить содержимое,
            foreach (string s in strArray)
            {
                Console.WriteLine("Entry: {0}", s);
            }
            Console.WriteLine();
        }

        static void SimpleBoxUnboxOperation()
        {
            // Создать переменную ValueType (int).
            int mylnt = 25;
            // Упаковать int в ссылку на object,
            object boxedlnt = mylnt;
            // Распаковать ссылку обратно в int.
            int unboxedlnt = (int)boxedlnt;

            // Распаковать в неподходящий тип данных, чтобы
            // инициировать исключение времени выполнения.
            try
            {
                long unboxedlntError = (long)boxedlnt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WorkWithArrayList()
        {
            // Типы значений автоматически упаковываются,
            // когда передаются члену, принимающему object.
            ArrayList mylnts = new ArrayList();
            mylnts.Add(10);
            mylnts.Add(20);
            mylnts.Add(35);
            //Распаковка происходит, когда объект преобразуется
            //обратно в данные, расположенные в стеке.
            int i = (int)mylnts[0];
            // Теперь значение вновь упаковывается, т.к.
            // метод WriteLine () требует типа object!
            Console.WriteLine("Value of your int: {0}", i);
        }

        static void UseGenericStack()
        {
            Stack<Person> stackOfPeople = new Stack<Person>();
            stackOfPeople.Push(new Person
            { FirstName = "Homer", LastName = "Simpson", Age = 47 });
            stackOfPeople.Push(new Person
            { FirstName = "Marge", LastName = "Simpson", Age = 45 });
            stackOfPeople.Push(new Person
            { FirstName = "Lisa", LastName = "Simpson", Age = 9 });
            // Просмотреть верхний элемент, вытолкнуть его и просмотреть снова.
            Console.WriteLine("First person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            Console.WriteLine("\nFirst person item is: {0}", stackOfPeople.Peek());
            Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            try
            {
                Console.WriteLine("\nnFirst person is: {0}", stackOfPeople.Peek());
                Console.WriteLine("Popped off {0}", stackOfPeople.Pop());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("\nError! {0}", ex.Message); // Ошибка! Стек пуст.
            }
        }

        static void GetCoffee(Person p)
        {
            Console.WriteLine("{0} got coffee!", p.FirstName);
        }

        static void UseGenericQueue()
        {
            // Создать очередь из трех человек.
            Queue<Person> peopleQ = new Queue<Person>();
            peopleQ.Enqueue(new Person
            {
                FirstName = "Homer",
                LastName = "Simpson",
                Age = 47
            });
            peopleQ.Enqueue(new Person
            {
                FirstName = "Marge",
                LastName = "Simpson",
                Age = 45
            });
            peopleQ.Enqueue(new Person
            {
                FirstName = "Lisa",
                LastName = "Simpson",
                Age = 9
            });
            // Заглянуть, кто первый в очереди.
            Console.WriteLine("{0} is first in line!", peopleQ.Peek().FirstName);
            // Удалить всех из очереди.
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            GetCoffee(peopleQ.Dequeue());
            // Попробовать извлечь кого-то из очереди снова,
            try
            {
                GetCoffee(peopleQ.Dequeue());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error! {0}", e.Message); // Ошибка! Очередь пуста.
            }
        }

        static void UseSortedSet()
        {
            // Создать несколько объектов Person с разными значениями возраста.
            SortedSet<Person> setOfPeople =
            new SortedSet<Person>(new SortPeopleByAge())
            {
                new Person {FirstName= "Homer", LastName="Simpson", Age=47},
                new Person {FirstName= "Marge", LastName="Simpson", Age=45},
                new Person {FirstName= "Lisa", LastName="Simpson", Age=9},
                new Person {FirstName= "Bart", LastName="Simpson", Age=8}
            };
            // Обратите внимание, что элементы отсортированы по возрасту.
            foreach (Person р in setOfPeople)
            {
                Console.WriteLine(р);
            }
            Console.WriteLine();
            // Добавить еще несколько объектов Person с разными значениями возраста.
            setOfPeople.Add(new Person
            {
                FirstName = "Saku",
                LastName = "Jones",
                Age = 1
            });
            setOfPeople.Add(new Person
            {
                FirstName = "Mikko",
                LastName = "Jones",
                Age = 32
            });
            // Элементы по-прежнему отсортированы по возрасту.
            foreach (Person p in setOfPeople)
            {
                Console.WriteLine(p);
            }
        }

        static void UseDictionary()
        {
            // Наполнить с помощью метода Add().
            Dictionary<string, Person> peopleA = new Dictionary<string, Person>();
            peopleA.Add("Homer", new Person
            {
                FirstName = "Homer",
                LastName = "Simpson",
                Age = 47
            });
            peopleA.Add("Marge", new Person
            {
                FirstName = "Marge",
                LastName = "Simpson",
                Age = 45
            });
            peopleA.Add("Lisa", new Person
            {
                FirstName = "Lisa",
                LastName = "Simpson",
                Age = 9
            });
            // Получить элемент с ключом Homer.
            Person homer = peopleA["Homer"];
            Console.WriteLine(homer);
            // Наполнить с помощью синтаксиса инициализации.
            Dictionary<string, Person> peopleB = new Dictionary<string, Person>()
            {
                {"Homer", new Person { FirstName = "Homer", LastName = "Simpson", Age = 47}},
                {"Marge", new Person { FirstName = "Marge", LastName = "Simpson", Age = 45 } },
                { "Lisa", new Person { FirstName = "Lisa", LastName = "Simpson", Age = 9 } }
            };
            // Получить элемент с ключом Lisa.
            Person lisa = peopleB["Lisa"];
            Console.WriteLine(lisa);
        }

        static void ObservableCollectionExample()
        {
            // Сделать коллекцию наблюдаемой и добавить в нее несколько объектов Person.
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
                new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            };
            // Привязаться к событию CollectionChanged.
            people.CollectionChanged += people_CollectionChanged;

        }

        static void people_CollectionChanged(object sender,
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Выяснить действие, которое привело к генерации события.
            Console.WriteLine("Action for this event: {0}", e.Action);
            // Было что-то удалено,
            if (e.Action ==
            System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the OLD items:"); // старые элементы
                foreach (Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();
            }
            // Было что-то добавлено.
            if (e.Action ==
            System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Теперь вывести новые элементы, которые были вставлены.
                Console.WriteLine("Here are the NEW items:"); // новые элементы
                foreach (Person p in e.NewItems)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }

        static void Swap<T>(ref T a, ref T b)
            where T : struct
        {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp = a;
            a = b;
            b = temp;
        }

        static void ExampleSwap()
        {
            // Обмен двух целочисленных значений
            int a = 10, b = 90;
            Console.WriteLine("Before swap: {0}, {1}", a, b);
            Swap<int>(ref a, ref b);
            Console.WriteLine("After swap: {0}, {1}", a, b);
            Console.WriteLine();
            // Обмен двух строковых значений,
            //string si = "Hello", s2 = "There";
            //Console.WriteLine("Before swap: {0} {1}'", si, s2);
            //Swap<string>(ref si, ref s2);
            //Console.WriteLine("After swap: {0} {1}!", si, s2);
        }
    }
}
