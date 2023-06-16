using Catalog.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.ProductAggregate.Entities
{
    public class Category : Entity<int>
    {
        private Category()
        {

        }
        public Category(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        private readonly List<Product> _products = new();
        public IReadOnlyList<Product> Products => _products.AsReadOnly();

    }
}
