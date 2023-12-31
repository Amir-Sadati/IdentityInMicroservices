﻿using Catalog.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddCatalogApplicationServices
            (this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMapsterConfiguration();
            return services;
        }
    }
}
