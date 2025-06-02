using ApiAppDemo.Application.Handlers.Borrowers.AddBorrower;
using ApiAppDemo.Application.Handlers.Borrowers.EditBorrower;
using ApiAppDemo.Application.Handlers.Borrowers.GetBorrowers;
using ApiAppDemo.Application.Handlers.Borrowers.GetBorrower;
using ApiAppDemo.Application.Handlers.Borrowers.RemoveBorrower;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppDemo.Controllers;

[Produces("application/json")]
[Route("[controller]")]
[ApiController]
//[Authorize]
public class BorrowersController : ControllerBase
{
    private readonly IMediator _mediator;

    public BorrowersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("getBorrowers")]
    public async Task<IActionResult> GetBorrowers()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new GetBorrowers());
        return Ok(result);
    }

    [HttpGet]
    [Route("getBorrower")]
    public async Task<IActionResult> GetBorrower([FromQuery] GetBorrowerParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new GetBorrower(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("AddBorrower")]
    public async Task<IActionResult> AddBorrower([FromBody] AddBorrowerParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new AddBorrower(parameters));
        return Ok(result);
    }

    [HttpDelete]
    [Route("removeBorrower")]
    public async Task<IActionResult> RemoveBorrower([FromBody] RemoveBorrowerParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new RemoveBorrower(parameters));
        return Ok(result);
    }

    [HttpPost]
    [Route("editBorrower")]
    public async Task<IActionResult> EditBorrower([FromBody] EditBorrowerParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _mediator.Send(new EditBorrower(parameters));
        return Ok(result);
    }
}
