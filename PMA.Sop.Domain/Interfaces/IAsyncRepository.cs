using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using PMA.Sop.ApplicationServices.Interfaces;

namespace PMA.Sop.Domain.Interfaces
{
    public interface IAsyncRepository<T> : IAggregateRoot
    {
        Task<T> GetByIdAsync<TKey>(TKey id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> FirstAsync(ISpecification<T> spec);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
        EntityState SoftDelete(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> RawSql(string query, params object[] parameters);
    }
}