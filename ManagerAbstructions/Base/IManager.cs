using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAbstructions.Base
{
    public interface IManager<T> where T : class
    {
        bool Add(T entity);
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        Task<bool> UpdateAsync(T entity);
        bool Remove(T entity);
        Task<bool> RemoveAsync(T entity);
        T GetById(int id);
        ICollection<T> GetAll();
        bool AddRange(ICollection<T> entity);
        Task<bool> AddRangeAsync(ICollection<T> entities);
        bool UpdateRange(ICollection<T> entity);
        Task<bool> UpdateRangeAsync(ICollection<T> entity);
        bool RemoveRange(ICollection<T> entity);
        Task<bool> RemoveRangeAsync(ICollection<T> entity);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(long id);
        ICollection<T> Get(Expression<Func<T, bool>> predicate = null);
        Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> predicate = null);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
