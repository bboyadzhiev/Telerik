using System;
using System.Linq;
using System.Linq.Expressions;
namespace MusicLibrary.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();

        IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        void Update(T entity);

        //void Delete(T entity);
        void Delete(object id);

        void Detach(T entity);
    }
}
