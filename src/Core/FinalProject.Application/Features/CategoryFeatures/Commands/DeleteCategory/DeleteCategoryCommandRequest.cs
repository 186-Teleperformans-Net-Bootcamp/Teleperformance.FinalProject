using FinalProject.Application.Wrappers.Responses;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<BaseResponse>
    {
        public string Id { get; set; }
    }
}
