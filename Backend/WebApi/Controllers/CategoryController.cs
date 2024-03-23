using Application.Features.CategoryFeatures.Commands;
using Application.Features.CategoryFeatures.Queries;
using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CategoryController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await Mediator.Send(new GetAllCategoryQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCateogry(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
