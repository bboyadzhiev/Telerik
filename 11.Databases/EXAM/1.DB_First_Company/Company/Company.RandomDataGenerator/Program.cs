namespace Company.RandomDataGenerator
{
    using Company.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main()
        {
            //var sqlServerPath = @".";
            //var sqlServerPath = @"(localdb)\v11.0";
            var sqlServerPath = @".\SQLEXPRESS";
            var connectionString = @"Data Source=" + sqlServerPath + @";Initial Catalog=Company;Integrated Security=True";
            Console.WriteLine("Connecting to SQL Server at " + sqlServerPath);
            Console.WriteLine("PLEASE CHANGE IF NEEDED");
            Console.WriteLine();

            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities(connectionString);
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<IDataGenerator>
            {
              new DepartmentDataGenerator(random, db, 100),
              new ProjectsDataGenerator(random, db, 1000),
              new EmployeeDataGenerator(random, db, 5000),
              new EmployeesProjectsRandomGenerator(random, db, 1000),
              new ReportsDataGenerator(random, db, 25000)
             // new DepartmentDataGenerator(random, db, 100),
             // new ProjectsDataGenerator(random, db, 200),
             // new EmployeeDataGenerator(random, db, 200),
             // new EmployeesProjectsRandomGenerator(random, db, 0),
             // new ReportsDataGenerator(random, db, 250)
            };

            foreach (var generator in listOfGenerators)
            {
                generator.Generate();
                db.SaveChanges();
            }

        }
    }
}
