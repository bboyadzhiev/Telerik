namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;

    public interface IStudentSystemData
    {
        IRepository<Course> Courses { get; }

        StudentsRepository Students { get; }

        IRepository<Test> Tests { get; }

        IRepository<Homework> Homeworks { get; }

        int SaveChanges();

    }
}
