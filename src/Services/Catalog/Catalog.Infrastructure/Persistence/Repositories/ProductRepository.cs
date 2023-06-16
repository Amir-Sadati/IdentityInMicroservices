using Catalog.Domain.Common.Interfaces;
using Catalog.Domain.ProductAggregate;
using Catalog.Infrastructure.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : CatalogBaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(CatalogDbContext catalogDbContext):base(catalogDbContext)
        {
            
        }

        public async Task<IEnumerable<Product>> GetProductWithCategories()
            => await Entity.Include(x => x.Categories).ToListAsync();


    }
}
