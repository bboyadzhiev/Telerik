namespace Cars.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cars.Data;
    class Program
    {
        static void Main()
        {
            //var sqlServerPath = @".";
            //var sqlServerPath = @"(localdb)\v11.0";
            var sqlServerPath = @".\SQLEXPRESS";
            var connectionString = @"Data Source=" + sqlServerPath + @";Initial Catalog=Cars;Integrated Security=True";
            Console.WriteLine("Connecting to SQL Server at " + sqlServerPath);
            Console.WriteLine("PLEASE CHANGE IF NEEDED");
            Console.WriteLine();

            var db = new CarsDBContext(connectionString);
            var cars = db.Cars.Any();

            Console.WriteLine(cars.ToString());
        }
    }
}
