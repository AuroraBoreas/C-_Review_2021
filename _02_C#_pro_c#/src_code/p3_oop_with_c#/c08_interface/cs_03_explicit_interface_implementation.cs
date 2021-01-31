using System;

namespace ExplicitInterfaceImplementation
{

    interface IDrawForm
    {
        void Draw();
    }

    interface IDrawInMemory
    {
        void Draw();
    }

    interface IDrawToPrinter
    {
        void Draw();
    }

    class Octagon0: IDrawForm, IDrawInMemory, IDrawToPrinter // version 0
    {
        public void Draw() // implicit; compiler allows access modifier "public"
        {
            System.Console.WriteLine("Drawing the Octagon...");
        }
    }
    class Octagon1: IDrawForm, IDrawInMemory, IDrawToPrinter // version 1
    {
        // explicit; compiler does NOT allow access modifier
        void IDrawForm.Draw()
        {
            // ...;
            System.Console.WriteLine("Drawing to Form...");
        }
        void IDrawInMemory.Draw()
        {
            // ...;
            System.Console.WriteLine("Drawing to Memory...");
        }
        void IDrawToPrinter.Draw()
        {
            // ...;w 
            System.Console.WriteLine("Drawing to Printer...");
        }
    }

    

    class Program
    {
        static int Main(string[] args)
        {
            // interfaces name clash
            {
                /*
                
                + general syntax pattern: `return_type InterfaceName.MethodName(params){};`

                + note: 
                    - when using this syntax pattern, you dont provide access modifier;
                    - explicitly implemented members are automatically private;

                + why:
                    - because explicitly implemented members are always implicitly private, these members are NO longer available from the obj-lvl;

                    - as a result, u MUST use explicit casting to access the required functionality;
                */
                FunWithInterfaceNameClash_implicit();
                FunWithInterfaceNameClash_explicit();
            }

            //
            {

            }

            return 0;
        }

        static void FunWithInterfaceNameClash_implicit()
        {
            System.Console.WriteLine("=> fun with interface name clash:");

            Octagon0 oct = new Octagon0();

            IDrawForm iform = (IDrawForm)oct;
            iform.Draw();

            IDrawInMemory iMemo = (IDrawInMemory)oct;
            iMemo.Draw();

            IDrawToPrinter iPrin = (IDrawToPrinter)oct;
            iPrin.Draw();

            Console.ReadLine();
            
        }
        static void FunWithInterfaceNameClash_explicit()
        {
            System.Console.WriteLine("=> fun with interface name clash:");

            Octagon1 oct = new Octagon1();

            IDrawForm iform = (IDrawForm)oct;
            iform.Draw();

            IDrawInMemory iMemo = (IDrawInMemory)oct;
            iMemo.Draw();

            IDrawToPrinter iPrin = (IDrawToPrinter)oct;
            iPrin.Draw();

            Console.ReadLine();
            
        }
        
    }
}