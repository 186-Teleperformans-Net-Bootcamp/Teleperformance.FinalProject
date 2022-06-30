using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, BaseResponse>
    {
        private readonly ICategoryCommandRepository _repository;

        public CreateCategoryCommandHandler(ICategoryCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category NewCategory= request.Adapt<Category>();
            await _repository.AddAsync(NewCategory);
            await _repository.SaveAsync();

            BaseResponse response = new()
            {
                Success = true,
                Message = "Category Added"
            };
            return response;
            throw new NotImplementedException();
        }
    }
}
