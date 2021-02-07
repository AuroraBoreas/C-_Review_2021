using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person() { }
        public Person(string firstName)
        : this(firstName, "noLastName", 1)
        { }
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName; LastName = lastName; Age = age;
        }
        public override string ToString()
        => $"Name: {FirstName} {LastName}, Age: {Age}";
    }

}
