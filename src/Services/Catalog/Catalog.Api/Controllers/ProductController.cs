using Catalog.Application.Dtos.ProductDtos;
using Catalog.Application.Features.ProductFeature.Commands;
using Catalog.Application.Features.ProductFeature.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Catalog.Api.Controllers
{
    public class ProductController : BaseCatalogApiController
    {
        [Authorize(Policy ="PD")]
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
           => HandleResult(await Mediator.Send(new GetAllProductQuery()));

        [Authorize(Policy = "AdminProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
            => HandleResult(await Mediator.Send(new CreateProductCommand(productDto)));

    }
}
