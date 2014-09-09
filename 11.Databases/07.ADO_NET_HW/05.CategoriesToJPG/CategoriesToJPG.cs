namespace _05.CategoriesToJPG
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Drawing.Imaging;
    using System.IO;

    internal class CategoriesToJPG
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

        private static int StoreProductsImages(string path, ImageFormat format, string fileExtension)
        {
            var imagesCount = 0;
            SqlCommand cmd = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    byte[] rawData = (byte[])reader["Picture"];
                    string fileName = path + reader["CategoryName"].ToString().Replace('/', '_') + "." + fileExtension;
                    int len = rawData.Length;
                    int header = 78;
                    byte[] imgData = new byte[len - header];
                    Array.Copy(rawData, 78, imgData, 0, len - header);

                    MemoryStream memoryStream = new MemoryStream(imgData);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                    image.Save(new FileStream(fileName, FileMode.Create), format);
                    imagesCount++;
                }
            }
            return imagesCount;
        }

        private static void Main(string[] args)
        {
            var path = "..\\..\\Images\\";
            var fileExtension = "jpeg";
            var imageFormat = ImageFormat.Jpeg;
            try
            {
                ConnectToDB();
                Console.WriteLine("{0} images exported", StoreProductsImages(path, imageFormat, fileExtension));
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