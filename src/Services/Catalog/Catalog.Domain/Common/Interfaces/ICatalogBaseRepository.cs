using Catalog.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Common.Interfaces
{
    public interface ICatalogBaseRepository<T,TId> where T : Entity<TId>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllByIdsAsync(List<TId> Ids);
        ValueTask<T?> FindAsync(params object?[]? keyValues);
        void Add(T entity);
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
    }
}
