using Catalog.Domain.Common.Interfaces;
using Catalog.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Persistence.Repositories.Common
{
    public abstract class CatalogBaseRepository<T,TId> : ICatalogBaseRepository<T,TId> where T : Entity<TId>
    {
        private readonly CatalogDbContext _catalogDbContext;
        protected DbSet<T> Entity => _catalogDbContext.Set<T>();
        protected CatalogBaseRepository(CatalogDbContext catalogDbContext)
        {
           _catalogDbContext = catalogDbContext;
        }

        public virtual async Task<List<T>> GetAllAsync() 
            => await Entity.ToListAsync();
        public virtual async Task<List<T>> GetAllByIdsAsync(List<TId> Ids)
           => await Entity.Where(x=>Ids.Contains(x.Id)).ToListAsync();
        public async ValueTask<T?>  FindAsync(params object?[]? keyValues)
            => await Entity.FindAsync(keyValues);
        public void Add(T entity) => Entity.Add(entity);
        public async Task AddAsync(T entity) => await Entity.AddAsync(entity);
        public async Task AddRangeAsync(List<T> entities,CancellationToken cancellationToken = default) 
            => await Entity.AddRangeAsync(entities,cancellationToken);
        public void Update(T entity) =>  Entity.Update(entity);
        public void UpdateRange(List<T> entities)
            => Entity.UpdateRange(entities);
        public void Remove (T entity) => Entity.Remove(entity);
        public void RemoveRange(List<T> entities) => Entity.RemoveRange(entities);
    }
}
