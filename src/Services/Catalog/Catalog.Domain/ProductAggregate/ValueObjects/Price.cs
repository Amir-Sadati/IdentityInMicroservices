using Catalog.Domain.Common.Models;
using Catalog.Domain.ProductAggregate.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.ProductAggregate.ValueObjects
{
    public class Price : ValueObject
    {
        private Price()
        {
        }
        private Price(decimal amount)
        {
            Amount = amount;
        }
        public decimal Amount { get; private set; }

        public static Price Create(decimal amount)
        {
            if (amount < 0)
                 throw new InvalidAmountException();

            return new Price(amount);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}
