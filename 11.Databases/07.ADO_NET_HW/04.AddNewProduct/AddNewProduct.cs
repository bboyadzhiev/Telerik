using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;

namespace _04.AddNewProductHW
{
    class AddNewProduct
    {
        private static SqlConnection dbConnection;

        private static void ConnectToDB()
        {
            // see app.config if chang to ConnectionString needed
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

        private static StringBuilder GetProducts()
        {
            SqlCommand cmd = new SqlCommand("SELECT ProductName FROM Products ORDER BY ProductName", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            var categories = new StringBuilder();
            using (reader)
            {
                while (reader.Read())
                {
                    categories.Append((string)reader["ProductName"] + "\n");
                }
            }
            return categories;
        }

        private static void AddProduct(Product p)
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO [Products]"
                +"([ProductName],[SupplierID],[CategoryID],[QuantityPerUnit],[UnitPrice],[UnitsInStock],[UnitsOnOrder],[ReorderLevel],[Discontinued]) "
                +" VALUES (@productName, @supplierID, @categoryID, @quantityPreUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued) "
                , dbConnection);
            cmd.Parameters.AddWithValue("@productName", p.ProductName);
            if (p.SupplierID == null)
            {
                cmd.Parameters.AddWithValue("@supplierID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@supplierID", p.SupplierID);
            }
            if (p.CategoryID == null)
            {
                cmd.Parameters.AddWithValue("@categoryID", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@categoryID", p.CategoryID);
            }
            cmd.Parameters.AddWithValue("@quantityPreUnit", p.QuantityPerUnit);
            cmd.Parameters.AddWithValue("@unitPrice", p.UnitPrice);
            cmd.Parameters.AddWithValue("@unitsInStock", p.UnitsInStock);
            cmd.Parameters.AddWithValue("@unitsOnOrder", p.UnitsOnOrder);
            cmd.Parameters.AddWithValue("@reorderLevel", p.ReorderLevel);
            cmd.Parameters.AddWithValue("@discontinued", p.Discontinued);

            
            int rowsAdded = cmd.ExecuteNonQuery();
            Console.WriteLine("{0} products added \n", rowsAdded);
        }

        private static void Main(string[] args)
        {
            StringBuilder products;
            try
            {
                ConnectToDB();
                Product pear = new Product("Apple", false);
                AddProduct(pear);

                products = GetProducts();
                Console.WriteLine("Product Name".ToUpper());
                Console.WriteLine(products);
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
