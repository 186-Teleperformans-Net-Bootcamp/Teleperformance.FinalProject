using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {

        [HttpGet]
        public IActionResult get()
        {
            return Ok("burası serbest alana gardas");
        }

    }
}
