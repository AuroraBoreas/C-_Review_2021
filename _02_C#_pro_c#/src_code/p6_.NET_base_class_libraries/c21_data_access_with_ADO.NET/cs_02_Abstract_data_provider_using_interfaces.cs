using System;
using static System.Console; // <-- laziness: Console.WriteLine(msg); => WriteLine(msg);

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

namespace AbstractDataUsingInterfaces
{

    enum DataProvider
    {
        SqlServer, OleDb, Odbc, None
    }
    class Program
    {
        static int Main(string[] args)
        {
            // 860
            {

            }

            //
            {

            }

            return 0;
        }

        static IDbConnection GetConnection(DataProvider dp)
        {
            IDbConnection conn = dp switch
            {
                DataProvider.SqlServer => new SqlConnection(),
                DataProvider.OleDb => new OleDbConnection(),
                DataProvider.Odbc => new OdbcConnection(),
            };

            return conn;
        }

        static void VerySimpleConnectionFactory()
        {
            System.Console.WriteLine("***** Very Simple Connection Facotry *****\n");

            IDbConnection myConnection = GetConnection(DataProvider.SqlServer);
            System.Console.WriteLine($"Your connection is a {myConnection.GetType().Name}");

            // open, use and close connection...
            Console.ReadLine();

        }

        static void VerySimpleConnectionFactory2()
        {
            System.Console.WriteLine("***** Very Simple Connection Facotry *****\n");

            string dataProviderString = ConfigurationManager.AppSettings["provider"];

            DataProvider dataProvider = DataProvider.None;
            if(Enum.IsDefined(typeof(DataProvider), dataProviderString))
            {
                dataProvider = (dataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
            }
            else
            {
                System.Console.WriteLine("sorry, no provider exists!");
                Console.ReadLine();
                return;
            }

            IDbConnection myConnection = GetConnection(dataProvider);
            System.Console.WriteLine($"Your connection is a {myConnection?.GetType().Name ?? "unrecognized type"}");

            // open, use and close connection...
            Console.ReadLine();
        }


    }
}
