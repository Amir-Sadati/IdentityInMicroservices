﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Exceptions.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg)
        {
            
        }
    }
}
