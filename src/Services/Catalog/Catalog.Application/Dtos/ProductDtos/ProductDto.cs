using Catalog.Application.Dtos.CategoryDtos;
using Catalog.Domain.ProductAggregate.Entities;
using Catalog.Domain.ProductAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Dtos.ProductDtos
{
    public class ProductDto
    {
        public decimal Price { get;  set; }
        public string Name { get;  set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
    }
}
