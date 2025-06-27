using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.ReturnBook;

public class ReturnBookHandler : ICommandHandler<ReturnBook, ReturnBookResponse>
{
    private readonly IBookRepository _bookRepository;
    public ReturnBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<ReturnBookResponse> Handle(ReturnBook request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId, cancellationToken);
        if (book == null)
        {
            return new ReturnBookResponse("Book with passed Id does not exists");
        }

        _bookRepository.ReturnBook(request.BookId, cancellationToken);

        return new ReturnBookResponse();
    }
}
