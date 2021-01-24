using System;
using System.Collections.Generic;
using System.Text;

namespace LCSOD_06_OOP_part02
{
    class VIPMember: Member
    {
        public VIPMember(string name, int memberID, int memberSince)
        : base(name, memberID, memberSince)
        {
            Console.WriteLine("derived class: VIPMember");
        }

        public override void calculateAnnualFee()
        {
            m_annualFee = 1200;
        }
    }
}
