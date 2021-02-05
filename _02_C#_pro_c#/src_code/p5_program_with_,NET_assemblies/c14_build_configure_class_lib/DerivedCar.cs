using System;

namespace CarLibrary
{
    public class MiniVan: Car
    {
        public MiniVan()
        : base("", 100, 30){}
        public MiniVar(string name, int maxSp, int curSp)
        : base(name, maxSp, curSp){}

        public override void TurboBoost()
        => $"Engine block is exploding!";

        public override string ToString()
        => $"Name:{PetName}, MaxSpeed: {MaxSpeed}, CurrentSpeed: {CurrentSpeed}";
    }

    public class SportsCar: Car
    {
        public SportsCar()
        : base("", 100, 30){}
        public SportsCar(string name, int maxSp, int curSp)
        : base(name, maxSp, curSp){}

        public override void TurboBoost()
        => $"fast is better!";

        public override string ToString()
        => $"Name:{PetName}, MaxSpeed: {MaxSpeed}, CurrentSpeed: {CurrentSpeed}";

    }
}