namespace _03.CategoriesAndProducts
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Text;

    public class CategoriesAndProducts
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

        private static StringBuilder GetCategoriesAndProducts()
        {
            SqlCommand cmd = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c JOIN Products p ON c.CategoryID = p.CategoryID ORDER BY c.CategoryName", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            var categories = new StringBuilder();
            using (reader)
            {
                while (reader.Read())
                {
                    categories.Append(String.Format("{0, -15}", (string)reader["CategoryName"]) + " | " + (string)reader["ProductName"] + "\n");
                }
            }
            return categories;
        }

        private static void Main(string[] args)
        {
            StringBuilder categoriesWithDescriptionAndProducts;
            try
            {
                ConnectToDB();
                categoriesWithDescriptionAndProducts = GetCategoriesAndProducts();
                Console.WriteLine(String.Format("{0, -15}", "Category Name".ToUpper()) + " | " + "Product Name".ToUpper());
                Console.WriteLine(categoriesWithDescriptionAndProducts);
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