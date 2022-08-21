using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Data.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        #region Constructor
        protected FinancContext _context;
        protected DbSet<T> DbSet => _context.Set<T>();
        protected IQueryable<T> Queryable => _context.Set<T>().AsNoTracking();
        public IQueryable<T> Query => Queryable;

        public GenericRepository(FinancContext context)
        {
            _context = context;
        }

        private void ChangeTracker_StateChanged(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntryEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Entry.ToString());
        }
        private void ChangeTracker_Tracked(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntryEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Entry.ToString());
        }
        #endregion

        public virtual T Add(T entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public virtual T Update(T entity)
        {
            var entry = _context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
            return entry.Entity;
        }

        public virtual T Update(T entity, params Expression<Func<T, object>>[] updateProperties)
        {
            //Ensure only modifiels are updated
            var dbEntityEntry = _context.Entry(entity);
            dbEntityEntry.State = EntityState.Unchanged;

            if (updateProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updateProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }
            return dbEntityEntry.Entity;
        }

        public virtual void Delete(T entity)
        {
            DbSet.Attach(entity);
            DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var del = Queryable.Where(predicate).AsEnumerable();
            DbSet.RemoveRange(del);
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = Queryable;

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return query.FirstOrDefaultAsync();
            }
        }

        public virtual Task<int> ExecSpAsync(string spName, SqlParameter[] parameters)
        {
            return _context.Database.ExecuteSqlRawAsync(spName, parameters);
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
