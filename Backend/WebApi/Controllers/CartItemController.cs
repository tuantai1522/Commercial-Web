using Application.Features.CartFeatures.Commands;
using Application.Features.CartItemFeatures.Commands;
using Application.Features.CartItemFeatures.Queries;
using Application.Features.CategoryFeatures.Queries;
using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Domain.RequestHelpers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CartItemController : BaseApiController
    {
        [HttpGet("{CustomerName}")]

        public async Task<IActionResult> GetCartItems(string CustomerName)
        {
            return Ok(await Mediator.Send(new GetCartItemsQuery { CustomerName = CustomerName }));
        }

        [HttpPost]
        public async Task<IActionResult> UpsertCartItem(UpsertCartItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartIteById(int id)
        {
            return Ok(await Mediator.Send(new DeleteCartItemByIdCommand { Id = id }));
        }
    }
}
