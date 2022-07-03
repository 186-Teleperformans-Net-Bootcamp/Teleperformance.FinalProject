using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryRequest : IRequest<GetCategoryByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
