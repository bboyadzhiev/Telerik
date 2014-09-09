namespace _06.ReadExcelFile
{
    using System;
    using System.Configuration;
    using System.Data.OleDb;
    using System.Text;

    internal class ReadExcelFile
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

        private static StringBuilder GetNamesAndScores()
        {
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Contestants$]", dbConnection);
            OleDbDataReader reader = cmd.ExecuteReader();
            var contestants = new StringBuilder();
            using (reader)
            {
                while (reader.Read())
                {
                    contestants.Append(
                        String.Format("{0, -15}", (string)reader["Name"]) + " | " + (double)reader["Score"] + "\n");
                }
            }
            return contestants;
        }

        private static void Main(string[] args)
        {
            StringBuilder namesAndScores;
            try
            {
                ConnectToDB();
                namesAndScores = GetNamesAndScores();
                Console.WriteLine(String.Format("{0, -15}", "Name".ToUpper()) + " | " + "Score".ToUpper());
                Console.WriteLine(namesAndScores);
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