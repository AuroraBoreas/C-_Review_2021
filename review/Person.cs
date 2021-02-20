using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Person
    {
        string m_Name;
        int m_Age;
        string m_Sex;
        int m_Account;
        double m_State;

        public Person() { }
        public Person(string name, int age, string sex, int account, double state)
        {
            m_Name = name;
            m_Age = age;
            m_Sex = sex;
            m_Account = account;
            m_State = state;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public int Account { get; set; }
        public double State { get; set;  }

        public override string ToString()
            => $"\n***AccountInfo***\nName:{Name}\nAge: {Age}\nSex:{Sex}\nAccount:{Account}\nState:{State}\n";

        // hash
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            Person tmp = obj as Person;
            return tmp.GetHashCode() == GetHashCode();
        }

    }

    public class SuperHero: Person
    {
        public int Speed { get; set; } = default;
        public string City { get; set; } = default;

        public SuperHero() { }

        public SuperHero(string name, int age, string sex, int account, double state, int speed, string city)
        : base(name, age, sex, account, state)
        {
            Speed = speed;
            City = city;
        }
    }
}
