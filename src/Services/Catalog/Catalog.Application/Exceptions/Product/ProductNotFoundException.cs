using Catalog.Application.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Exceptions.Product
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int Id) :base ($"Product with Id {Id} not found ")
        {
            
        }
    }
}
