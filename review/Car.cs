using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    // delegate
    public class EngineEventArgs
    {
        public string Info { get; }
        public EngineEventArgs(string info)
        {
            Info = info;
        }
    }

    public class Car
    {
        public string Name { get; set; } = string.Empty;
        public int CurrentSpeed { get; set; } = default;
        public int MaxSpeed { get; set; } = default;
        public string Color { get; set; } = string.Empty;
        private bool IsEngineDead = false;

        // ctor
        public Car(string name)
        : this(name, 0, 0, "")
        { }

        public Car(string name, int curSp, int MaxSp, string color)    // master ctor
        {
            Name = name; CurrentSpeed = curSp; MaxSpeed = MaxSp; Color = color;
        }
        // override
        public override string ToString()
        => $"Name: {this.Name}, CurrentSpeed: {this.CurrentSpeed}, MaxSpeed: {this.MaxSpeed}, Color: {this.Color}";

        public delegate void EngineHandle(object sender, EngineEventArgs e);
        // event
        public event EngineHandle EngineEvent;
        // method
        public void Accelerate(int delta)
        {
            CurrentSpeed += delta;
            if(IsEngineDead)
            {
                EngineEvent?.Invoke(this, new EngineEventArgs("Engine is dead..."));
            }
            else
            {
                if (CurrentSpeed > MaxSpeed)
                {
                    IsEngineDead = true;
                    EngineEvent?.Invoke(this, new EngineEventArgs("Engine is dead..."));
                }
                else if (20 >= Math.Abs( MaxSpeed - CurrentSpeed))
                {
                    EngineEvent?.Invoke(this, new EngineEventArgs($"be careful bro! CurrentSpeed: {CurrentSpeed}."));
                }
                else
                {
                    EngineEvent?.Invoke(this, new EngineEventArgs($"faster is better! CurrentSpeed: {CurrentSpeed}."));
                }
            }

        }

    }

    

}
