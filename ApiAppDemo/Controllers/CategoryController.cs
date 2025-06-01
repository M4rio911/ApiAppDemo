using ApiAppDemo.Application.Handlers.Categories.AddCategory;
using ApiAppDemo.Application.Handlers.Categories.EditCategory;
using ApiAppDemo.Application.Handlers.Categories.GetCategories;
using ApiAppDemo.Application.Handlers.Categories.GetCategory;
using ApiAppDemo.Application.Handlers.Categories.RemoveCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppDemo.Controllers;

[Produces("application/json")]
[Route("[controller]")]
[ApiController]
//[Authorize]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getCategories")]
    public async Task<IActionResult> GetCategories()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new GetCategories());
        return Ok(result);
    }

    [HttpGet]
    [Route("getCategory")]
    public async Task<IActionResult> GetCategory([FromQuery] GetCategoryParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new GetCategory(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("AddCategory")]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new AddCategory(parameters));
        return Ok(result);
    }

    [HttpDelete]
    [Route("removeCategory")]
    public async Task<IActionResult> RemoveCategory([FromBody] RemoveCategoryParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new RemoveCategory(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("editCategory")]
    public async Task<IActionResult> EditCategory([FromBody] EditCategoryParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new EditCategory(parameters));
        return Ok(result);
    }
}
