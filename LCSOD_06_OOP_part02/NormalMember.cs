using System;
using System.Collections.Generic;
using System.Text;

namespace LCSOD_06_OOP_part02
{
    class NormalMember: Member
    {
        private string m_remark;
        public NormalMember()
        { Console.WriteLine("derived class: NormalMember"); }

        public NormalMember(string remarks)
        : base("ZL", 1, 2013)
        { Console.WriteLine("Remark = {0}", remarks); }

        public NormalMember(string name, int memberID, int memberSince, string remark)
        : base(name, memberID, memberSince)
        { m_remark = remark; }

        public override void calculateAnnualFee()
        {
            m_annualFee = 100 + 12 * 30;
        }
    }
}
