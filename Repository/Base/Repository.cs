using Microsoft.EntityFrameworkCore;
using RepositoryAbstruction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext _dbContext;

        DbSet<T> Table
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual bool Add(T entity)
        {
            Table.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        private int GetTotalPageSize(int totalCount, int batchSize)
        {

            // include this if when you always want at least 1 page 
            if (totalCount == 0)
            {
                return 1;
            }

            return totalCount % batchSize != 0
                ? totalCount / batchSize + 1
                : totalCount / batchSize;
        }

        public virtual bool Update(T entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public virtual bool Remove(T entity)
        {
            Table.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public virtual async Task<bool> RemoveAsync(T entity)
        {
            Table.Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> RemoveRangeAsync(ICollection<T> entity)
        {
            Table.RemoveRange(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual T GetById(int id)
        {
            return Table.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await Table.FindAsync(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public virtual ICollection<T> Get(Expression<Func<T, bool>> predicate)
        {
            return GetQueryable().ToList();
        }

        public virtual bool UpdateRange(ICollection<T> entity)
        {
            Table.UpdateRange(entity);

            return _dbContext.SaveChanges() > 0;
        }

        public virtual bool RemoveRange(ICollection<T> entity)
        {
            Table.RemoveRange(entity);
            return _dbContext.SaveChanges() > 0;
        }


        public virtual async Task<bool> UpdateAsync(T entity)
        {
            Table.Update(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> UpdateRangeAsync(ICollection<T> entity)
        {
            _dbContext.UpdateRange(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<ICollection<T>> GetAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await GetQueryable(predicate).ToListAsync();
        }

        public virtual bool AddRange(ICollection<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            return _dbContext.SaveChanges() > 0;
        }

        public virtual async Task<bool> AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbContext.Set<T>().AsQueryable();
            }
            return _dbContext.Set<T>().Where(predicate).AsQueryable();
        }

        public virtual async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
        }

    }
}