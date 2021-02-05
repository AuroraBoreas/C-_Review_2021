using System;

namespace CarLibrary
{
    public enum EngineState
    {
        engineAlive,
        engineDead,
    }

    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        protected EngineState engineState = EngineState.engineAlive;
        public EngineState EngineState => engineState;
        public abstract void TurboBoost();

        public Car(){}
        public Car(string name, int maxSp, int currSp)
        {
            PetName = name; MaxSpeed = maxSp; CurrentSpeed = currSp;
        }

        public abstract void TurboBoost();

        public virtual string ToString();
    }
}