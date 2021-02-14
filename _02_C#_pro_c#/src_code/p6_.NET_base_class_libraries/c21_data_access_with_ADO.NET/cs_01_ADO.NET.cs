using System;
using System.Data;


namespace ADO_NET
{
    class Program
    {
        static int Main(string[] args)
        {
            // P850
            {
                /*

                + note
                    - ADO(MS COM-based data access model, Active Data Object);
                    - ADO.NET has little to do with ADO beyond the letters A, D, and O;

                    - namespace: System.Data;

                */
            }

            // Three faces of ADO.NET
            {
                /*

                + three conceptually unique manners

                    - "connected" layer

                    - "disconnected" layer

                    - "through an ORM" such as the Entity Framework;


                */
            }


            // ADO.NET data providers
            {
                /*

                + what does ADO.NET do?
                    - ADO.NET supports multiple data providers;
                    - each of which is optimized to innteract with a specific DBMS;


                + benefits
                    - 1, this approach is that u can program a specific data provide to access ANY unique features of a particular DBMS;

                    - 2, a specific data provide can connnect directly to the underlying engine of the DBMS in question without an intermediate mapping layer standing btwn the tiers;

                + data provider?
                    - a set of types defined in a given namespace that understand how to communicate with a specific type of data source;

                    ```c#

                    namespace System.Data
                    {
                        public class Connection{}

                        public class Command{}

                        public class DataReader{}

                        public class DataAdapter{}

                        public class Parameter{}

                        public class Transaction{}

                    }

                    ```
                + MS ADO.NET Data provider
                    - OLE DB;                           System.Data.OleDb
                    - Microsoft SQL Server LocalDb;     System.Data.SqlClient
                    - ODBC;                             System.Data.Odbc
                */
            }

            // select additional ADO.NET-centric namespaces
            {
                /*

                + Microsoft.SqlServer.Server

                + System.Data

                + System.Data.Common

                + System.Data.Sql

                + System.Data.SqlTypes


                */
            }


            // core members of System.Data namespace
            {
                /*

                + core members
                    - Constraint

                    - DataColumn
                    - DataRow
                    - DataSet
                    - DataTable
                    - DataView

                    - DataRelation
                    - DataTableReader


                    // interface
                    - IDataAdapter
                    - IDataParameter
                    - IDataReader
                    - IDbCommand
                    - IDbDataAdapter
                    - IDbTransaction

                */
            }

            // IDbConnection interface
            {
                /*

                + definition
                    ```c#

                    namespace System.Data
                    {
                        public interface IDbConnection: IDispoable
                        {
                            string ConnectionString { get; set; }
                            int ConnetionTimeout { get; }
                            string Database { get; }
                            ConnectionState State { get; }

                            IDbTransaction BeginTransaction();
                            IDbTransaction BeginTransaction(IsolationLevel il);
                            void ChangeDatabase(string databaseName);
                            void Close();
                            IDbCommand CreateCommand();
                            void Open();
                        }
                    }

                    ```


                */
            }

            // IDbTransaction interface
            {

            }

            return 0;
        }



    }
}
