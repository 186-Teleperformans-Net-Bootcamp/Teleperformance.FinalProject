﻿using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory;
using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Application.Features.ProductFeatures.Commands.DeleteProduct;
using FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FinalProject.Application.Wrappers.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FinalProject.Application.Features.ProductFeatures.Queries.GetProductById;

namespace FinalProject.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductByShopList([FromQuery] GetAllProductByCategoryQueryRequest request)
        {

            GetAllProductByCategoryQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.Products);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQueryRequest request)
        {
            GetProductByIdQueryResponse response = await _mediator.Send(request);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.Product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]CreateProductCommandRequest request)
        {
            BaseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody]UpdateProductCommandRequest request)
        {
            BaseResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]DeleteProductCommandRequest request)
        {
            BaseResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
