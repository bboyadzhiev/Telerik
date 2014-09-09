namespace _02.CategoriesDescription
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using Northwind.Entities;

    internal class CategoriesDescription
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

        private static IList<Category> GetCategories()
        {
            SqlCommand cmd = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            var categories = new List<Category>();
            using (reader)
            {
                while (reader.Read())
                {
                    var category = new Category(
                        (string)reader["CategoryName"], 
                        (string)reader["Description"]
                        );
                    categories.Add(category);
                }
            }
            return categories;
        }

        private static void Main(string[] args)
        {
            IList<Category> categoriesWithDescription;
            try
            {
                ConnectToDB();
                categoriesWithDescription = GetCategories();

                foreach (var category in categoriesWithDescription)
                {
                    Console.WriteLine(category.Name.ToUpper() +": " + category.Description);
                }
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