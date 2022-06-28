using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductCommandRepository _repository;

        public CreateProductCommandHandler(IProductCommandRepository repository)
        {
            _repository = repository;
        }

        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
