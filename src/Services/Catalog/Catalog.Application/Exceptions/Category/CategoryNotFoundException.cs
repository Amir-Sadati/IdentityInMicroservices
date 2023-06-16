using Catalog.Application.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Exceptions.Category
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int Id) : base($"category with Id {Id} not found ")
        {

        }
    }
}
