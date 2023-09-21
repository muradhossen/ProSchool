using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAbstruction.Base
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        Task<bool> AddAsync(T entity);

        bool AddRange(ICollection<T> entity);
        Task<bool> AddRangeAsync(ICollection<T> entities);

        bool Update(T entity);

        Task<bool> UpdateAsync(T entity);

        bool UpdateRange(ICollection<T> entity);

        Task<bool> UpdateRangeAsync(ICollection<T> entity);
        bool Remove(T entity);
        Task<bool> RemoveAsync(T entity);
        bool RemoveRange(ICollection<T> entity);
        Task<bool> RemoveRangeAsync(ICollection<T> entity);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(long id);
        ICollection<T> GetAll();

        Task<ICollection<T>> GetAllAsync();

        ICollection<T> Get(Expression<Func<T, bool>> predicate = null);

        Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate = null);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        // Task<bool> BatchInsertAsync(ICollection<T> entities, Func<DbContext> contextCreator);
    }
}