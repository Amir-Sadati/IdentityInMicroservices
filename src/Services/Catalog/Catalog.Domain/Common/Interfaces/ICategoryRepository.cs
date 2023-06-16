using Catalog.Domain.ProductAggregate;
using Catalog.Domain.ProductAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Common.Interfaces
{
    public interface ICategoryRepository : ICatalogBaseRepository<Category, int>
    {
    }
}
