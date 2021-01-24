using System;
using System.Collections.Generic;
using System.Text;

namespace LCSOD_06_OOP_part02
{
    class DerivedClass: MyClass
    {
        public override void myAbstractMethod()
        {
            throw new NotImplementedException();
        }
    }
}
