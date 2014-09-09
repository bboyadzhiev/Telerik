namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StudentSystem.Data;
    using StudentSystem.Model;
    using System.Data.Entity;
    using StudentSystem.Data.Migrations;
    public class ConsoleClient
    {
        static void Main()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
            //.\SQLEXPRESS
           // var connectionString = "StudentSystem_SQLEXPRESS";
            // .
            //var connectionString = "StudentSystem"; 
            var db = new StudentSystemDbContext();

            var students = db.Students.Where(s => s.Age > 5);
            foreach (var student in students)
            {
                Console.WriteLine(student.Name);
            }
        }
    }
}
