﻿using FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopListByUser;
using FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList;
using FinalProject.Application.Wrappers.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using MediatR;
using FinalProject.Application.Features.ShopListFeatures.Commands.UpdateShopList;
using FinalProject.Application.Features.ShopListFeatures.Commands.DeleteShopList;
using FinalProject.Application.Features.ShopListFeatures.Queries.GetShopListById;
using FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList;

namespace FinalProject.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/mylists")]
    [ApiController]
    public class ShopListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShopListByUser([FromQuery] GetAllShopListByUserQueryRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            request.UserId = Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            GetAllShopListByUserQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.Lists);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetShopListById([FromRoute] GetShopListByIdQueryRequest request)
        {
            GetShopListByIdQueryResponse response = await _mediator.Send(request);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.ShopList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShopList(CreateShopListCommandRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            request.AppUserId = Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            BaseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShopList([FromBody] UpdateShopListCommandRequest request)
        {
            BaseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletedShopList([FromRoute] DeleteShopListCommandRequest request)
        {

            BaseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin/lists-of-all-user")]
        public async Task<IActionResult> GetAllShopList([FromQuery] GetAllShopListQueryRequest request)
        {
            GetAllShopListQueryResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
/*
 
  path deneme

 [Httppath("{Id}")]
        public async Task<IActionResult> DeletedShopList([FromRoute] x(ıd) , [FromBody] y(jsonserliaz))
        {
            a =    x.Adapt<DeleteShopListCommandRequest>();
            a =    y.Adapt<DeleteShopListCommandRequest>();
            BaseResponse response = await _mediator.Send(a);

            return Ok(response);
        }

 */
//TODO Queryleri trendyol ashibinden vs bakarak isimleini düzenle