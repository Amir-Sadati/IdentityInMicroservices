using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Common.Models
{
    public class AggregateRoot<TId> : Entity<TId>
    {

        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
     
        public void AddDomainEvent(IDomainEvent domainEvent) =>
            _domainEvents.Add(domainEvent);
      

        public void ClearDomainEvents() =>
            _domainEvents.Clear();
       
    }
}
