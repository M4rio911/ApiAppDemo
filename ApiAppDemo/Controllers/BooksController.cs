using ApiAppDemo.Application.Handlers.Books.AddBook;
using ApiAppDemo.Application.Handlers.Books.BorrowBook;
using ApiAppDemo.Application.Handlers.Books.EditBook;
using ApiAppDemo.Application.Handlers.Books.GetBook;
using ApiAppDemo.Application.Handlers.Books.GetBooks;
using ApiAppDemo.Application.Handlers.Books.RemoveBook;
using ApiAppDemo.Application.Handlers.Books.ReturnBook;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppDemo.Controllers;

[Produces("application/json")]
[Route("[controller]")]
[ApiController]
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

    [HttpGet]
    [Route("getBook")]
    public async Task<IActionResult> GetBook([FromHeader] GetBookParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new GetBook(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("AddBook")]
    [Authorize]
    public async Task<IActionResult> AddBook([FromBody] AddBookParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new AddBook(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("removeBook")]
    [Authorize]
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
    [Authorize]
    public async Task<IActionResult> EditBook([FromBody] EditBookParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new EditBook(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("returnBook")]
    [Authorize]
    public async Task<IActionResult> ReturnBook([FromBody] ReturnBookParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new ReturnBook(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("borrowBook")]
    [Authorize]
    public async Task<IActionResult> BorrowBook([FromBody] BorrowBookParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new BorrowBook(parameters));
        return Ok(result);
    }
}
