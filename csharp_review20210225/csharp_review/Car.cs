using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public abstract class Car
    {
        public string Maker { get; set; }
        public int MaxSpeed { get; set; }
        public int CurrentSpeed { get; set; }
        private bool IsEngineDead;

        public Car(){}
        public Car(string maker, int maxSp, int curSp)
        {
            Maker = maker;
            MaxSpeed = maxSp;
            CurrentSpeed = curSp;
        }
        public override string ToString()
        => $"\nMaker: {Maker}\nMaxSpeed: {MaxSpeed}\nCurrentSpeed: {CurrentSpeed}";

        public virtual void Accelerate()
        {
            Console.WriteLine("Car is accelerating..");
        }

        public abstract void Repair();
    }

    public class SportsCar: Car
    {
        public string Color { get; set; }
        public SportsCar(){}

        public SportsCar(string maker, int maxSp, int curSp, string color)
        : base(maker, maxSp, curSp)
        { Color = color; }

        public override string ToString()
        => $"\nMaker:{Maker}\nMaxSpeed:{MaxSpeed}\nCurrentSpeed:{CurrentSpeed}\nColor:{Color}";
        public override bool Equals(object obj)
        {
            SportsCar sp = obj as SportsCar;
            return ToString().Equals(sp.ToString());
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override void Accelerate()
        { Console.WriteLine("SportsCar is accelerating.."); }

        public override void Repair()
        { Console.WriteLine("SportsCar is repairing.."); }
    }

    public class SportsCarCollection: IEnumerable
    {
        private SportsCar[] coll;
        public SportsCarCollection(ref SportsCar[] sCars)
        {
            coll = sCars;
        }
        public IEnumerator GetEnumerator()
        {
            return coll.GetEnumerator();
        }
        public SportsCar this[int i]
        {
            get { return coll[i]; }
            set { coll[i] = value; }
        }
    }
}
