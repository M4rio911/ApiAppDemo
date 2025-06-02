using ApiAppDemo.Application.Handlers.Books.AddBook;
using ApiAppDemo.Application.Handlers.Books.EditBook;
using ApiAppDemo.Application.Handlers.Books.GetBooks;
using ApiAppDemo.Application.Handlers.Books.RemoveBook;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppDemo.Controllers;

[Produces("application/json")]
[Route("[controller]")]
[ApiController]
//[Authorize]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getBooks")]
    public async Task<IActionResult> GetBooks()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new GetBooks());
        return Ok(result);
    }

    [HttpPost]
    [Route("AddBook")]
    public async Task<IActionResult> AddBook([FromBody] AddBookParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new AddBook(parameters));
        return Ok(result);
    }

    [HttpDelete]
    [Route("removeBook")]
    public async Task<IActionResult> RemoveBook([FromBody] RemoveBookParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new RemoveBook(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("editBook")]
    public async Task<IActionResult> EditBook([FromBody] EditBookParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new EditBook(parameters));
        return Ok(result);
    }
}
