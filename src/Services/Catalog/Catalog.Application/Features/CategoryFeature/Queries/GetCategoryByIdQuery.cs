using Catalog.Application.Dtos.CategoryDtos;
using Catalog.Application.Exceptions.Category;
using Catalog.Domain.Common.Interfaces;
using Mapster;
using MediatR;
using SharedKernel.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.CategoryFeature.Queries
{
    public record GetCategoryByIdQuery(int Id) : IRequest<Result<CategoryDto>>;

    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery,Result<CategoryDto>>
    {
        private readonly ICatalogCatalogUnitOfWork _unitOfWork;

        public GetCategoryByIdQueryHandler(ICatalogCatalogUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.FindAsync(request.Id);
            if (category is null)
                throw new CategoryNotFoundException(request.Id);

            return Result<CategoryDto>.Success(category.Adapt<CategoryDto>());
        }
    }


}
