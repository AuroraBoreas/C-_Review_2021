using System;

namespace LCSOD_06_OOP_part02
{
    class Program
    {
        static void Main(string[] args)
        {
            // inheritance
            {
                NormalMember nm1 = new NormalMember("ZL", 1, 2013, "Special Rate");
                VIPMember vm1 = new VIPMember("SCY", 2, 2011);

                nm1.calculateAnnualFee();
                vm1.calculateAnnualFee();

                Console.WriteLine(nm1.ToString());
                Console.WriteLine(vm1.ToString());

            }

            // polymorphism
            {
                Member[] clubMembers = new Member[5];
                clubMembers[0] = new VIPMember("ZL", 1, 2013);
                clubMembers[1] = new NormalMember("SCY", 2, 2011, "special rate");
                clubMembers[2] = new NormalMember("LL", 3, 2011, "special rate");
                clubMembers[3] = new VIPMember("LM", 4, 2012);
                clubMembers[4] = new VIPMember("LL", 5, 2012);

                string isVIP;
                foreach(Member m in clubMembers)
                {
                    m.calculateAnnualFee();
                    Console.WriteLine(m.ToString());
                    isVIP = (m.GetType() == typeof(VIPMember))? "Yes" : "No";
                    Console.WriteLine("VIP membership? : {0}", isVIP);
                }
            }

            // abstraction
            {

            }
        }
    }
}
