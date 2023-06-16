using Catalog.Application.Dtos.ProductDtos;
using Catalog.Application.Features.CategoryFeature.Queries;
using Catalog.Application.Features.ProductFeature.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{

    public class CategoryController : BaseCatalogApiController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> CreateProduct(int Id)
          => HandleResult(await Mediator.Send(new GetCategoryByIdQuery(Id)));
    }
}
