using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Domain.Entities.Enums;
using Microsoft.AspNetCore.Mvc;


namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductCommandRepository _repository;

        public ProductsController(IProductCommandRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            bool b = await _repository.AddAsync(new Domain.Entities.Product()
            {
                //Id = Guid.NewGuid(),
                Name = "Cips",
                Quantity = 1,
                MeasurementType = MeasurementType.Piece
            });
            _repository.SaveAsync();
            return Ok("eklendi ellamm" + b);
        }
    }
}
