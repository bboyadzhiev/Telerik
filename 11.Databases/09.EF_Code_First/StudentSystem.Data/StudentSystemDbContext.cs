namespace StudentSystem.Data
{
    using StudentSystem.Data.Migrations;
    using StudentSystem.Model;
    using System.Data.Entity;

    public class StudentSystemDbContext : DbContext
    {
        public StudentSystemDbContext(string connectionString)
            : base(connectionString) 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());
        }
        public StudentSystemDbContext()
            : base("StudentSystem_SQLEXPRESS")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDbContext, Configuration>());

        }
        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }
    }
}