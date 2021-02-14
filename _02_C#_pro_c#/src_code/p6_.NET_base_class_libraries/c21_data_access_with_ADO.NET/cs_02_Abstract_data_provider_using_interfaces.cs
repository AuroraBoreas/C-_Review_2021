using System;
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

        static void VerySimpleConnectionFactory()
        {
            System.Console.WriteLine("***** Very Simple Connection Facotry *****\n");

            IDbConnection myConnection = GetConnection(DataProvider.SqlServer);
            System.Console.WriteLine($"Your connection is a {myConnection.GetType().Name}");

            // open, use and close connection...
            Console.ReadLine();

        }

    }
}
