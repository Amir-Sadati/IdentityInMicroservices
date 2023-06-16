using Catalog.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Catalog.Domain.Common.Interfaces
{
    public interface IProductRepository : ICatalogBaseRepository<Product, int>
    {
    }
}
