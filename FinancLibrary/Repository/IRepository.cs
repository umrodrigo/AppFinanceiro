using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Financ.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query { get; }
        T Add(T entity);
        T Update(T entity);
        T Update(T entity, params Expression<Func<T, object>>[] updateProperties);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        Task<int> ExecSpAsync(string spName, SqlParameter[] parameters);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<int> SaveAsync();

    }
}