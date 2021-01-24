using System;
using System.Collections.Generic;
using System.Text;

namespace LCSOD_06_OOP_part02
{
    class Member
    {
        protected int m_annualFee;
        private string m_name;
        private int m_memberID;
        private int m_memberSince;

        public Member() { Console.WriteLine("default constructor"); }
        public Member(string name, int memberID, int memberSince)
        {
            m_name = name;
            m_memberID = memberID;
            m_memberSince = memberSince;
        }

        public override string ToString()
        {
            return $"\nName: {m_name} \nMember ID: {m_memberID} \nMember Since: {m_memberSince} \nTotal Annual Fee: {m_annualFee}";
        }

        public virtual void calculateAnnualFee()
        {
            m_annualFee = 1;
        }
    }
}
