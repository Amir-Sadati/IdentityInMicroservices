using Catalog.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.ProductAggregate.Events
{
    public class ProductCreatedEvent : IDomainEvent
    {
        public int Id { get; set; }
    }
}
