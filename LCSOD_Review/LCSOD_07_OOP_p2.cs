using System;
using System.Collections.Generic;

// pattern: ncm?
namespace LCSOD_07_OOP_p2
{
    class Program
    {
        static void Main(string[] args)
        {
            // A E I P 
            {
                /*

                */
                List<Member> customers = new List<Member>
                {
                    new NormalMember("ZL", 111, 2013, "special rate"),
                    new NormalMember("SCY", 123, 2011, "special rate"),
                    new VIPMember("LL", 142, 2011, "VIP"),
                    new VIPMember("LM", 118, 2012, "VIP"),
                    new NormalMember("XY", 120, 2014, "special rate")
                };

                // loop
                Console.WriteLine("is VIP? : ");
                string res;

                // polymorphism
                foreach(Member m in customers)
                {
                    res = m.GetType() == typeof(VIPMember)? "Yes" : "No";
                    Console.WriteLine($"is VIP? : {res}");
                }

                // LINQ
                var res =
                    from cust in customers
                    where cust.MemberSince > 2012
                    orderby cust.MemberSince
                    select new { cust.Name, cust.MemberSince };
                
                foreach(var r in res)
                {
                    Console.WriteLine($"{r.Name}, {r.memberSince}");
                }


            }
        }
    }
}