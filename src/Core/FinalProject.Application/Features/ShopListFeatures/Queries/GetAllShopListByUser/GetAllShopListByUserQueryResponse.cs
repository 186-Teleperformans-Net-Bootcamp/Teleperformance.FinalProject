using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;


namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopListByUser
{
    public class GetAllShopListByUserQueryResponse : BaseResponse
    {
        public List<ShopList> Lists { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
