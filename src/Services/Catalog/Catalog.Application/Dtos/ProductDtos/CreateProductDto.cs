using Catalog.Application.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Dtos.ProductDtos
{
    public class CreateProductDto : ProductDto
    {
        public List<int> CategoryIds { get; set; }
    }
}
