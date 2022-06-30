using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Models.Paging;
using FinalProject.Domain.Entities;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetShopListByUser
{
    public class GetShopListByUserQueryHandler : IRequestHandler<GetShopListByUserQueryRequest, GetShopListByUserQueryResponse>
    {
        private readonly IShopListQueryRepository _repository;

        public GetShopListByUserQueryHandler(IShopListQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetShopListByUserQueryResponse> Handle(GetShopListByUserQueryRequest request, CancellationToken cancellationToken)
        {

            IQueryable<ShopList> Lists = _repository.GetWhere(x => x.AppUserId == request.UserId);
            if (request.IsCompleted)
            {
                Lists = Lists.Where(x => x.IsCompleted == true);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchByName))
            {
                Lists = Lists.Where(x => x.Name.Contains(request.SearchByName));
            }

            if (request.CreationRangeCeiling.HasValue || request.CreationRangeLower.HasValue)
            {
                Lists = Lists.Where(x => x.CreationDate <= request.CreationRangeCeiling && x.CreationDate >= request.CreationRangeLower);
            }

            if (request.UpdateRangeCeiling.HasValue || request.UpdateRangeLower.HasValue)
            {
                Lists = Lists.Where(x => x.CreationDate <= request.UpdateRangeCeiling && x.CreationDate >= request.CreationRangeLower);
            }

            int TotalUser = Lists.Count();
            int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);
            int Skip = (request.Page - 1) * request.Limit;

            PagingInfo PageInfo = new()
            {
                TotalData = TotalUser,
                TotalPage = TotalPage,
                PageLimit = request.Limit,
                PageNum = request.Page,
                HasNext = request.Page >= TotalPage ? false : true,
                HasPrevious = request.Page == 1 ? false : true,
            };

            return new GetShopListByUserQueryResponse()
            {
                PagingInfo = PageInfo ,
                Lists = Lists.Skip(Skip).Take(request.Limit).ToList()
            };
            //throw new NotImplementedException();
        }
    }
}
