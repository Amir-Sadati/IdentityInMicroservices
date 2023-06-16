using Catalog.Application.Dtos.ProductDtos;
using Catalog.Domain.Common.Interfaces;
using Mapster;
using MediatR;
using SharedKernel.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.ProductFeature.Queries
{
    public record GetAllProductQuery : IRequest<Result<IEnumerable<ProductDto>>>;

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, Result<IEnumerable<ProductDto>>>
    {
        private readonly ICatalogCatalogUnitOfWork _unitOfWork;

        public GetAllProductQueryHandler(ICatalogCatalogUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<IEnumerable<ProductDto>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            if(products.Count > 0)
                return Result<IEnumerable<ProductDto>>.Success(products.Adapt<List<ProductDto>>());

            return Result<IEnumerable<ProductDto>>.Failure("No products found.");
        }
            
        
    }


}
