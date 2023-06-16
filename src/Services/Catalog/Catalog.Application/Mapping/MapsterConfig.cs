using Catalog.Application.Dtos.CategoryDtos;
using Catalog.Application.Dtos.ProductDtos;
using Catalog.Domain.ProductAggregate;
using Catalog.Domain.ProductAggregate.Entities;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mapping
{
    public static class MapsterConfig
    {
        public static void AddMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Product, ProductDto>
                .NewConfig()
                .Map(x => x.Price, x => x.Price.Amount);

            //TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());


        }
    }
 
}
