using ApiAppDemo.Application.Handlers.Authors.AddAuthor;
using ApiAppDemo.Application.Handlers.Authors.EditAuthor;
using ApiAppDemo.Application.Handlers.Authors.GetAuthors;
using ApiAppDemo.Application.Handlers.Authors.GetAuthor;
using ApiAppDemo.Application.Handlers.Authors.RemoveAuthor;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppDemo.Controllers;

[Produces("application/json")]
[Route("[controller]")]
[ApiController]
//[Authorize]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getAuthors")]
    public async Task<IActionResult> GetAuthors()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new GetAuthors());
        return Ok(result);
    }

    [HttpGet]
    [Route("getAuthor")]
    public async Task<IActionResult> GetAuthor([FromQuery] GetAuthorParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new GetAuthor(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("addAuthor")]
    [Authorize]
    public async Task<IActionResult> AddAuthor([FromBody] AddAuthorParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new AddAuthor(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("removeAuthor")]
    [Authorize]
    public async Task<IActionResult> RemoveAuthor([FromBody] RemoveAuthorParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new RemoveAuthor(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("editAuthor")]
    [Authorize]
    public async Task<IActionResult> EditAuthor([FromBody] EditAuthorParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new EditAuthor(parameters));
        return Ok(result);
    }
}
