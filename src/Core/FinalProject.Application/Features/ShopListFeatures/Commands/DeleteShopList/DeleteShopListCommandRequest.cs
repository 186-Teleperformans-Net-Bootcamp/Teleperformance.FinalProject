﻿using FinalProject.Application.Wrappers.Responses;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.DeleteShopList
{
    public class DeleteShopListCommandRequest : IRequest<BaseResponse>
    {
        public string Id { get; set; }
    }
}
