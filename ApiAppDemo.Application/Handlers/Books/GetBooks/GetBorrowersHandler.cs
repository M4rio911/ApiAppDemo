using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.GetBooks;

public class GetBorrowersHandler : ICommandHandler<GetBooks, GetBooksResponse>
{
    private readonly IBookRepository _bookRepository;
    public GetBorrowersHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<GetBooksResponse> Handle(GetBooks request, CancellationToken cancellationToken)
    {
        var dbBooks = await _bookRepository.GetBooksAsync(cancellationToken);

        return new GetBooksResponse() { Books = dbBooks };
    }
}