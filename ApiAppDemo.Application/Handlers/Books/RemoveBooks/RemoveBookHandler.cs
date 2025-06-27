using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.RemoveBook;

public class RemoveBookHandler : ICommandHandler<RemoveBook, RemoveBookResponse>
{
    private readonly IBookRepository _bookRepository;
    public RemoveBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<RemoveBookResponse> Handle(RemoveBook request, CancellationToken cancellationToken)
    {
        var dbBook = await _bookRepository.GetByIdAsync(request.BookId, cancellationToken);
        if (dbBook == null)
        {
            return new RemoveBookResponse("Book with passed Id does not exists");
        }

        await _bookRepository.RemoveBook(dbBook.Id, cancellationToken);

        return new RemoveBookResponse();
    }
}
