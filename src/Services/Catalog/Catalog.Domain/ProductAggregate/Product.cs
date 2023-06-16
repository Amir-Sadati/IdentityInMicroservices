using Catalog.Domain.Common.Models;
using Catalog.Domain.ProductAggregate.Entities;
using Catalog.Domain.ProductAggregate.Exceptions;
using Catalog.Domain.ProductAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.ProductAggregate
{
    public class Product : AggregateRoot<int>
    {
        private Product()
        {
        }
        public Product(string name, string title, string description,List<Category> categories, Price price)
        {
            Name = name;
            if (IsValidTitleLength(title))
                Title = title;

            Description = description;
            _categories = categories;
            Price = price;
        }
        private readonly List<Category> _categories = new();
        public IReadOnlyList<Category> Categories => _categories.AsReadOnly();
        public Price Price { get; private set; }
        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        private bool IsValidTitleLength(string title)
        {
            if ( title.Length > 100)
                throw new InvalidTitleLengthException();

            return true;
         
        }
    
    }
}
