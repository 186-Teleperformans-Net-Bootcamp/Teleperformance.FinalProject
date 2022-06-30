using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;


namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetShopListByUser
{
    public class GetShopListByUserQueryResponse : BaseResponse
    {
        public List<ShopList> Lists { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
