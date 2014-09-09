namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(StudentSystem.Data.StudentSystemDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Students.AddOrUpdate(
              p => p.Name,
              new Student { Name = "Andrew Peters", Age = 15, Number = 10 },
              new Student { Name = "Brice Lambson", Age = 16, Number = 11 },
              new Student { Name = "Rowan Miller", Age = 17, Number = 12 }
            );

            context.Courses.AddOrUpdate(
                c => c.Name,
                new Course { Name = "C Sharp I", Description = "A sharp course" },
                new Course { Name = "C Sharp II", Description = "A sharper course" },
                new Course { Name = "OOP", Description = "The sharpest course" }
                );
            context.SaveChanges();

        }
    }
}
