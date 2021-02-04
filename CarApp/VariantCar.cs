using System;
using System.Windows.Forms;

namespace CarLibrary
{
     public class SportsCar : Car
     {
        public SportsCar() { }
        public SportsCar(string name, int maxSp, int curSp)
        : base(name, maxSp, curSp) {}

        public override void TurboBoost()
        {
            MessageBox.Show("fast is better!");
        }
     }

    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSp, int curSp)
        : base(name, maxSp, curSp) { }

        public override void TurboBoost()
        {
            MessageBox.Show("Engine block exploded!");
        }
    }
}