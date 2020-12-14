using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMA.Sop.DAL.Context;
using PMA.Sop.Domain.Interfaces;
using PMA.Sop.Framework.Domain;

namespace PMA.Sop.DAL.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class, IAggregateRoot
    {
        protected readonly DatabaseContext DbContext;
        private readonly DbSet<T> _dbSet;

        public EfRepository(DatabaseContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync<TKey>(TKey id, bool asNoTracking = false)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync(bool asNoTracking = false)
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, bool asNoTracking = false)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<int> CountAsync(ISpecification<T> spec, bool asNoTracking = false)
        {
            var specificationResult = ApplySpecification(spec);
            if (asNoTracking)
                return await specificationResult.AsNoTracking().CountAsync();
            return await specificationResult.CountAsync();
        }

        public virtual async Task<T> FirstAsync(ISpecification<T> spec, bool asNoTracking = false)
        {
            var specificationResult = ApplySpecification(spec);
            if (asNoTracking)
                return await specificationResult.AsNoTracking().FirstAsync();
            return await specificationResult.FirstAsync();
        }

        public virtual async Task<T> FirstOrDefaultAsync(ISpecification<T> spec, bool asNoTracking = false)
        {
            var specificationResult = ApplySpecification(spec);
            if (asNoTracking)
                return await specificationResult.AsNoTracking().FirstOrDefaultAsync();
            return await specificationResult.FirstOrDefaultAsync();
        }

        public virtual EntityState SoftDelete(T entity)
        {
            entity.GetType().GetProperty(nameof(BaseEntity<T>.IsRemoved))?.SetValue(entity, true);
            entity.GetType().GetProperty(nameof(BaseEntity<T>.RemoveTime))?.SetValue(entity, DateTime.Now);
            return _dbSet.Update(entity).State;
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public virtual IQueryable<T> RawSql(string query, params object[] parameters)
        {
            return _dbSet.FromSqlRaw(query, parameters);
        }

        public async Task<IReadOnlyList<T>> GetPagedRespondAsync(int pageNumber, int pageSize)
        {
            return await _dbSet
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new SpecificationEvaluator<T>();
            return evaluator.GetQuery(_dbSet.AsQueryable(), spec);
        }

    }
}