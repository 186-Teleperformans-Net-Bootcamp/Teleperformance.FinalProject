using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Models.Paging;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory
{
    public class GetAllProductByCategoryQueryResponse
    {
        public List<GetProductDto> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
