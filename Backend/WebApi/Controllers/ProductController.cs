using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Domain.RequestHelpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.ProductFeatures.Commands.UpdateProductByIdCommand;

namespace WebApi.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParams productParams)
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery{ productParams = productParams}));
        }

        [HttpGet("{id}/getProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
    }
}
