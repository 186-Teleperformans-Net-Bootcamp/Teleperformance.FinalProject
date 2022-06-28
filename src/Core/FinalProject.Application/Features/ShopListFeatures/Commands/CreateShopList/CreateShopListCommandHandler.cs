using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList
{
    public class CreateShopListCommandHandler : IRequestHandler<CreateShopListCommandRequest, CreateShopListCommandResponse>
    {
        private readonly IShopListCommandRepository _repository;

        public CreateShopListCommandHandler(IShopListCommandRepository repository)
        {
            _repository = repository;
        }

        public Task<CreateShopListCommandResponse> Handle(CreateShopListCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
