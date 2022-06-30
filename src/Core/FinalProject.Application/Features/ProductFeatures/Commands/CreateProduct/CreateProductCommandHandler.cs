using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, BaseResponse>
    {
        private readonly IProductCommandRepository _repository;

        public CreateProductCommandHandler(IProductCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product NewProduct = request.Adapt<Product>();
            await _repository.AddAsync(NewProduct);
            await _repository.SaveAsync();
            BaseResponse response = new()
            {
                Success = true,
                Message = "Product Added"
            };
            return response;
        }

    }
}
