using System;
using System.Collections.ObjectModel;

namespace Collections_ObjectModel
{
    class Person: IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(){}
        public Person(string fn, string ln, int a)
        { FirstName = fn; LastName = ln; Age = a; }

        public override string ToString()
        => $"Name: {FirstName} {LastName}, Age: {Age}";

        int IComparable<Person>.CompareTo(Person other)
        => this.Age.CompareTo(other.Age);
    }

    public enum NotifyCollectionChangedAction
    {
        Add = 0,
        Remove,
        Replace,
        Move,
        Reset = 4,
    }

    class Program
    {
        static int Main(string[] args)
        {
            // System.Collections.ObjectModel, P405
            {
                /*
                
                + Useful Members
                    - ObservableCollection<T>           // represent a dynamic data collection that provides notifications when items get added, removed, or whole list is refreshed
                    - ReadOnlyObservableCollection<T>   // represent a read-only version of ObservableCollection<T>

                + ObservableCollection
                    - uniqueness: it supports an event named CollectionChanged;


                */ 

            }

            // work with ObservableCollection<T> class
            {
                UseObjectModel_ObservableCollection(); 
            }

            return 0;
        }

        private static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // what was the action that caused the event?
            System.Console.WriteLine("Action for this event: {0}", e.Action);

            // the removed sth
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                System.Console.WriteLine("here are the OLD items:");
                foreach(Person p in e.OldItems)
                    System.Console.WriteLine(p.ToString());
                System.Console.WriteLine();
            }

            // added sth
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                System.Console.WriteLine("here are the NEW items:");
                foreach(Person p in e.NewItems)
                    System.Console.WriteLine(p.ToString());
            }
        }
        
        static void UseObjectModel_ObservableCollection()
        {
            System.Console.WriteLine("=> use ObservableCollection:");

            ObservableCollection<Person> people = new ObservableCollection<Person>
            {
                new Person{FirstName="PP", LastName="DD", Age=52},
                new Person{FirstName="KK", LastName="VV", Age=48},
            };

            people.RemoveAt(0);

            // wire up the CollectionChanged event
            people.CollectionChanged += people_CollectionChanged;

        }
        
    }
}