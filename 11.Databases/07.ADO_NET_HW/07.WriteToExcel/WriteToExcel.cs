using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;

namespace _07.WriteToExcel
{
    internal class WriteToExcel
    {
        private static OleDbConnection dbConnection;

        private static void ConnectToDB()
        {
            ConnectionStringSettings dBConnectionString = ConfigurationManager.ConnectionStrings["ExcelFile"];
            dbConnection = new OleDbConnection(dBConnectionString.ConnectionString);
            dbConnection.Open();
        }

        private static void DisconnectFromDB()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
        }

        private static int AddContestants(IDictionary<string, double> contestants)
        {
            var count = 0;
            foreach (var contestant in contestants)
            {
                OleDbCommand cmd = new OleDbCommand("INSERT INTO [Contestants$]([Name], [Score]) VALUES (@name, @score)", dbConnection);
                cmd.Parameters.AddWithValue("@name", contestant.Key);
                cmd.Parameters.AddWithValue("@score", contestant.Value);
                count += cmd.ExecuteNonQuery();
            }
            return count;
        }

        private static void Main(string[] args)
        {
            var contestants = new Dictionary<string, double>()
                {
                    {"Ivaylo Kenov", 23},
                    {"George Hristov", 20},
                    {"George 2", 20},
                    {"George 3", 20}
                };
            int contastantsAdded;
            try
            {
                ConnectToDB();
                contastantsAdded = AddContestants(contestants);
                Console.WriteLine("{0} rows added", contastantsAdded);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured: {0}", ex);
            }
            finally
            {
                DisconnectFromDB();
            }
        }
    }
}