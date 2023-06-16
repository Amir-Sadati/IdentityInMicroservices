using Catalog.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Persistence.Repositories.Common
{
    public class CatalogUnitOfWork : ICatalogCatalogUnitOfWork
    {
        private readonly CatalogDbContext _catalogDbContext;

        public CatalogUnitOfWork(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
            => _productRepository ??= new ProductRepository(_catalogDbContext);

        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
            => _categoryRepository ??= new CategoryRepository(_catalogDbContext);

        public bool SaveChanges() => _catalogDbContext.SaveChanges() > 0;

    }
}
