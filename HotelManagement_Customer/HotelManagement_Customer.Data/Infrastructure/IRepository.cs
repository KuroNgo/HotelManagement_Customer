using System;
using System.Linq;
using System.Linq.Expressions;

namespace HotelManagement_Customer.Data.Infrastructure
{
    // This is a generic, used to all class in my project
    // Define some method
    // where T : class : define generates
    // T: represent a type that we do not know yet
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be removed
        void Delete(int id);

        //Delete multi records
        void DeleteMulti(Expression<Func<T, bool>> where);

        //Get an entity by int id
        T GetSingleById(int id);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);

        IQueryable<T> GetAll(string[] includes = null);

        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);
        int Count(Expression<Func<T, bool>> where);
        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
