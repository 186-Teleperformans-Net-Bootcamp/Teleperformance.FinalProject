using FinalProject.Application.Features.ShopListFeatures.Queries.GetShopListByUser;
using FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList;
using FinalProject.Application.Wrappers.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using MediatR;

namespace FinalProject.API.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/MyLists")]
    [ApiController]
    public class ShopListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopListsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetShopListByUser([FromQuery] GetShopListByUserQueryRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            request.UserId = Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            GetShopListByUserQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShopList(CreateShopListCommandRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            request.AppUserId = Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value;
            BaseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AllLists")]
        public async Task<IActionResult> Get()
        {


            return Ok("admin hg gardaş");
        }
    }
}
