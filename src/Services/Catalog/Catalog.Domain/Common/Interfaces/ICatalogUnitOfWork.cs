using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Common.Interfaces
{
    public interface ICatalogCatalogUnitOfWork
    {
         IProductRepository ProductRepository { get; }
         ICategoryRepository CategoryRepository { get; }
         bool SaveChanges();

    }
}
