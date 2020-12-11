using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace PMA.Sop.Domain.Interfaces
{
    public interface IAsyncRepository<T> : IAggregateRoot
    {
        Task<T> GetByIdAsync<TKey>(TKey id, bool asNoTracking = false);
        Task<IReadOnlyList<T>> ListAllAsync(bool asNoTracking = false);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, bool asNoTracking = false);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> CountAsync(ISpecification<T> spec, bool asNoTracking = false);
        Task<T> FirstAsync(ISpecification<T> spec, bool asNoTracking = false);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, bool asNoTracking = false);
        EntityState SoftDelete(T entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> RawSql(string query, params object[] parameters);
        Task<IReadOnlyList<T>> GetPagedRespondAsync(int pageNumber, int pageSize);
    }
}