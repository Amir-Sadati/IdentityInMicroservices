using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.ProductAggregate.Exceptions
{
    public class InvalidTitleLengthException : Exception
    {
        public InvalidTitleLengthException() : base("Title length must be less than or equal to 100 characters.")
        { 
        }
    }
}
