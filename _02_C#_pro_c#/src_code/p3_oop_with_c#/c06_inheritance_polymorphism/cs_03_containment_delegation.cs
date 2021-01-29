using System;

namespace Containment_Delegation
{

    class BenefitPackage
    {
        public double ComputePayDeduction()
        { return 125.0; }
    }

    partial class Employee
    {
        protected BenefitPackage empBenefits = new BenefitPackage();
        // ...;
    }

    partial class Employee
    {
        public double GetBenefitCost()
        { return empBenefits.ComputePayDeduction(); }

        public BenefitPackage Benefits
        {
            get => empBenefits;
            set => empBenefits = value;
        }
    }

    class SalesPerson: Employee
    {}

    class Manager: Employee
    {}

    class Employee2
    {
        public class BenefitPackage
        {
            public double ComputePayDeduction() { return 125.0; }
        }

        // ...;
    }

    class OuterClass
    {
        public class PublicInnerCls{}
        private class PrivateInnerCls{}
    }

    


    class Program
    {


        static int Main(string[] args)
        {
            // containment/delegation mode or aggregation, P282
            {
                /*

                + concept
                    - containment is it what it is
                    - delegation is simply the act of adding public members to the containing class that use the contained object's functionality
                
                + why?
                    - using other class as an "has-a" relationship, when inheritance "is-a" relationship between the two classes makes no sense

                */ 
                FuckEmployeeClsHierarchy();

            }

            // nested type, P283
            {
                /*
                function inside of function, why not class inside of class?
                
                + concept
                    - in c++, u can NOT add access modifiers to class definition
                    - in c#, u can add access modifiers to nested classes

                + why
                    - nested type allows u to gain complete control over the access level of the inner type
                    - u can access private members of the containing class
                    - often, a nested type is useful only as a helper for the outer class and it NOT intended for use by the outside world 
                
                + nested depth
                    - as deep as u may want
                */ 

            }

            return 0;
        }

        static void FuckEmployeeClsHierarchy()
        {
            System.Console.WriteLine("=> Fuck Employee class hierarchy:");

            Manager m1 = new Manager();
            double cost = m1.GetBenefitCost();
            Console.ReadLine();
        }


    }
}