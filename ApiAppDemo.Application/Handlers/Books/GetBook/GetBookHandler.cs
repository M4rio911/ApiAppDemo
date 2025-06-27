using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.GetBook;

public class GetBookHandler : ICommandHandler<GetBook, GetBookResponse>
{
    private readonly IBookRepository _bookRepository;
    public GetBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GetBookResponse> Handle(GetBook request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id, cancellationToken);

        return new GetBookResponse() { Book = book };
    }
}