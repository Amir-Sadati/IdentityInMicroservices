using Catalog.Application.Dtos.ProductDtos;
using Catalog.Domain.Common.Interfaces;
using Catalog.Domain.ProductAggregate;
using Catalog.Domain.ProductAggregate.Entities;
using Catalog.Domain.ProductAggregate.ValueObjects;
using MediatR;
using SharedKernel.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.ProductFeature.Commands
{
    public record CreateProductCommand(CreateProductDto ProductDto) :IRequest<Result<Unit>>;

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Unit>>
    {
        private readonly ICatalogCatalogUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(ICatalogCatalogUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<Unit>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

           var categories = await _unitOfWork.CategoryRepository.GetAllByIdsAsync
                (request.ProductDto.CategoryIds);
            if(categories.Count > 0)
            {
               var product = new Product(request.ProductDto.Name,
               request.ProductDto.Title, request.ProductDto.Description,
               categories,
               Price.Create(request.ProductDto.Price));
               
               await _unitOfWork.ProductRepository.AddAsync(product);

               if (_unitOfWork.SaveChanges())
                   return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failure("Failed to create product");

        }
    }



}
