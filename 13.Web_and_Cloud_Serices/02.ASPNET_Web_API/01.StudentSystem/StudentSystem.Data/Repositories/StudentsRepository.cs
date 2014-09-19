namespace StudentSystem.Data.Repositories
{
    using StudentSystem.Models;
    using System.Linq;
    using System.Data.Entity;

    public class StudentsRepository : EFRepository<Student>, IRepository<Student>
    {
        public StudentsRepository(DbContext context)
            : base(context)
        {

        }

        public IQueryable<Student> AllAsistants()
        {
            return this.All().Where(st => st.Trainees.Count() > 0);
        }
    }
}
