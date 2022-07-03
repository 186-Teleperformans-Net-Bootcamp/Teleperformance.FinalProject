using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetShopListById
{
    public class GetShopListByIdQueryRequest : IRequest<GetShopListByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
