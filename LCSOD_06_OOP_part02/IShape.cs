using System;
using System.Collections.Generic;
using System.Text;

namespace LCSOD_06_OOP_part02
{
    interface IShape
    {
        int MyNumber
        { get; set; }

        void IMethod();

    }


    class A: IShape
    {
        private int m_MyNumber;

        // constructors
        public A() { m_MyNumber = 0; }

        public int MyNumber
        { 
            get
            { return m_MyNumber; }

            set
            { m_MyNumber = value > 0 ? value: 0 ; } 
        }

        public void IMethod()
        { Console.WriteLine("My number is {0}", m_MyNumber);  }
    }
}
