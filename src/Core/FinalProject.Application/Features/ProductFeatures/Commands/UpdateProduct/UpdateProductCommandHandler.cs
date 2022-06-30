using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, BaseResponse>
    {
        private readonly IProductCommandRepository _Commandrepository;
        private readonly IProductQueryRepository _Queryrepository;

        public UpdateProductCommandHandler(IProductCommandRepository commandrepository, IProductQueryRepository queryrepository)
        {
            _Commandrepository = commandrepository;
            _Queryrepository = queryrepository;
        }

        public async Task<BaseResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product UpdatedProduct = await _Queryrepository.GetByIdAsync(request.Id);
            request.Adapt<UpdateProductCommandRequest, Product>(UpdatedProduct);

            _Commandrepository.Update(UpdatedProduct);
            await _Commandrepository.SaveAsync();
            BaseResponse response = new()
            {
                Success = true,
                Message = "Product Updated"
            };
            return response;


            throw new NotImplementedException();
        }
    }
}
