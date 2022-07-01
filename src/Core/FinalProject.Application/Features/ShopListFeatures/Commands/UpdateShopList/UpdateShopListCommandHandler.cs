using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.UpdateShopList
{
    public class UpdateShopListCommandHandler : IRequestHandler<UpdateShopListCommandRequest, BaseResponse>
    {
        private readonly IShopListCommandRepository _commandRepository;
        private readonly IShopListQueryRepository _queryRepository;

        public UpdateShopListCommandHandler(IShopListCommandRepository commandRepository, IShopListQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }


        public async Task<BaseResponse> Handle(UpdateShopListCommandRequest request, CancellationToken cancellationToken)
        {
            ShopList UpdatedShopList = await _queryRepository.GetByIdAsync(request.Id);
            request.Adapt<UpdateShopListCommandRequest, ShopList>(UpdatedShopList);

            _commandRepository.Update(UpdatedShopList);
            await _commandRepository.SaveAsync();
            BaseResponse response = new()
            {
                Success = true,
                Message = "ShopList Updated"
            };
            return response;


            throw new NotImplementedException();
        }
    }
}
