using FinalProject.Application.Features.UserFeatures.Commands.CheckUser;
using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{  //xss
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommandRequest request)
        {
            CreateUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> CheckUser([FromBody] CheckUserCommandRequest request)
        {
            CheckUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
