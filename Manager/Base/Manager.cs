using ManagerAbstructions.Base;
using RepositoryAbstruction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Base
{
    public class Manager<T> : IManager<T> where T : class
    {
        IRepository<T> _repository;

        public Manager(IRepository<T> repository)
        {
            _repository = repository;
        }



        public virtual bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public virtual bool Update(T entity)
        {
            return _repository.Update(entity);
        }

        public virtual bool Remove(T entity)
        {
            return _repository.Remove(entity);
        }
        public virtual async Task<bool> RemoveAsync(T entity)
        {
            return await _repository.RemoveAsync(entity);
        }

        public virtual T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual async Task<bool> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual bool AddRange(ICollection<T> entity)
        {
            return _repository.AddRange(entity);
        }

        public virtual async Task<bool> AddRangeAsync(ICollection<T> entities)
        {
            return await _repository.AddRangeAsync(entities);
        }

        public virtual bool UpdateRange(ICollection<T> entity)
        {
            return _repository.UpdateRange(entity);
        }

        public virtual async Task<bool> UpdateRangeAsync(ICollection<T> entity)
        {
            return await _repository.UpdateRangeAsync(entity);
        }

        public virtual bool RemoveRange(ICollection<T> entity)
        {
            return _repository.RemoveRange(entity);
        }

        public virtual async Task<bool> RemoveRangeAsync(ICollection<T> entity)
        {
            return await _repository.RemoveRangeAsync(entity);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _repository.Get(predicate);
        }

        public virtual async Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetAsync(predicate);
        }

        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _repository.GetFirstOrDefault(predicate);
        }

        public virtual async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetFirstOrDefaultAsync(predicate);
        }
    }
}