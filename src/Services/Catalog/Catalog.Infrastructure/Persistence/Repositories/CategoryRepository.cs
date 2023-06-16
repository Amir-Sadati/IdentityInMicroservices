using Catalog.Domain.Common.Interfaces;
using Catalog.Domain.ProductAggregate.Entities;
using Catalog.Infrastructure.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : CatalogBaseRepository<Category,int> , ICategoryRepository
    {
        public CategoryRepository(CatalogDbContext catalogDbContext):base(catalogDbContext)
        {
            
        }
    }
}
