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
        public int MaxSpeed { get; set; }
        public int CurrentSpeed { get; set; }
        private EngineState engineState = EngineState.engineAlive;
        public EngineState EngineState => engineState;

        public Car() {}
        public Car(string name, int maxSp, int curSp)
        { PetName = name; MaxSpeed = maxSp; CurrentSpeed = curSp; }

        public abstract void TurboBoost();

        public override string ToString()
        => $"Name: {PetName}, MaxSpeed: {MaxSpeed}, CurrentSpeed: {CurrentSpeed}";
    }

}
