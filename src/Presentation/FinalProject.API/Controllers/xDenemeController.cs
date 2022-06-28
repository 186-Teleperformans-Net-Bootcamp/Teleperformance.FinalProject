using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class xDenemeController : ControllerBase
    {
        private readonly IProductCommandRepository _repository;
        private readonly IShopListQueryRepository _repository2;

      

        //[HttpGet]
        //public async IActionResult get()
        //{
        //    bool b = await _repository.AddAsync(new Domain.Entities.Product()
        //    {
        //       Id = Guid.NewGuid(),
        //       Name = "kırmızı elma",
        //       Quantity = 2,
        //       MeasurementType = Domain.Entities.Enums.MeasurementType.Kg
        //    });
        //    return Ok("burası serbest alana gardas");
        //}

    }
}
