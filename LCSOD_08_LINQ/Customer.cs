using System;
using System.Collections.Generic;
using System.Text;

namespace LCSOD_08_LINQ
{
    class Customer
    {
        private string m_name;
        private string m_ID;
        private string m_addr;
        private decimal m_balance;

        // constructors
        public Customer(string name, string ID, string addr, decimal balance)
        {
            m_name = name;
            m_ID = ID;
            m_addr = addr;
            m_balance = balance;
        }

        // getter, setter
        public string Name
        {
            get
            { return m_name; }
            set
            { m_name = value; }
        }
        public string ID
        { get; set; }
        public string AddressW
        { get; set; }
        public decimal Balance
        {
            get
            { return m_balance; }

            set
            { m_balance = value; }
        }

        // repr
        public override string ToString()
        {
            return string.Format("\nName: {0} \nID: {1} \nAddress: {2} \nBalance: {3}", m_name, m_ID, m_addr, m_balance);
        }


    }
}
