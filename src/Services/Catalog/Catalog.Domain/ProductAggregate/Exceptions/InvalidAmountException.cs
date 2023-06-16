using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.ProductAggregate.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException() : base("Amount must be greater than zero")
        {
        }
    }
}
