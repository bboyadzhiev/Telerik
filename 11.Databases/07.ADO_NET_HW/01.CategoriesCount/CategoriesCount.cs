namespace _01.CategoriesCount
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    internal class CategoriesCount
    {
        private static SqlConnection dbConnection;

        private static void ConnectToDB()
        {
            ConnectionStringSettings dBConnectionString = ConfigurationManager.ConnectionStrings["Northwind"];
            dbConnection = new SqlConnection(dBConnectionString.ConnectionString);//Settings.Default.DBConnectionString);
            dbConnection.Open();
        }

        private static void DisconnectFromDB()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
        }

        private static int GetCategoriesCount()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) as [Count] FROM Categories", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    return (int)reader["Count"];
                }
            }
            return 0;
        }

        private static void Main(string[] args)
        {
            try
            {
                ConnectToDB();
                Console.WriteLine("The Categories count is {0}", GetCategoriesCount());
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