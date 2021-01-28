using System;
using System.Numerics; // for BigIntegers
using System.Text;     // for mutable strings

/*
wait, it does not compile as well.

procedures:
- add reference and select System.Numerics.dll

*/

// ancm?

namespace Pilosohpy
{
    class Program
    {
        static int Main(string[] args)
        {
            /*

            philosophy

            + why: Uniform and generalize all languages(C++, VB, C#, F#) in .NET
            
            + compilation pattern:
                src code -> .NET compilers -> IL(assemblies) -> machine code
            
            + library pattern:
                CTS: common type system
                CLS: common language specifications
                mscorlib.dll
                mscoree.dll
            
            + Object Viewer, ildasm.exe
                - shortcut: VS console -> ildasm
            
            + more details on paper notebook
                ...


            + the instrinsic CTS data types table, P79
                CTS data types      capacity
                System.Byte         1
                System.SByte        1
                System.Boolean      1
                System.Decimal      16

                System.Char         1
                System.Int16        2
                System.Int32        4
                System.Int64        8
                System.UInt16       2
                System.UInt32       4
                System.UInt64       8

                System.Single       4 (float in C++)
                System.Double       8

                System.Object       4 or 8(system depended)
                System.String       0 - 2 billion unicode characters

            + .NET namespaces table, P85
                .NET Namespace                          Meaning in life
                
                System

                System.Collections
                System.Collections.Generic

                System.Data
                System.Data.Common
                System.Data.EntityClient
                System.Data.SqlClient

                System.IO
                System.IO.Compression
                System.IO.Ports
                
                System.Reflection
                System.Reflection.Emit
                
                System.Runtime.InteropService

                System.Drawing
                
                System.Windows
                System.Windows.Forms
                System.Windows.Controls
                System.Windows.Shapes

                System.Linq
                System.Xml.Linq
                System.Data.DataSetExtensions

                System.Web
                System.Web.Http

                System.ServiceModel

                System.Workflow.Runtime
                System.Workflow.Activities

                System.Threading
                System.Threading.Tasks
                
                System.Security

                System.Xml
                
                


            */
        }

    }
}