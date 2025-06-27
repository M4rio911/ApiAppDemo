using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.EditBook;

public class EditBookHandler : ICommandHandler<EditBook, EditBookResponse>
{
    private readonly IBookRepository _bookRepository;
    public EditBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<EditBookResponse> Handle(EditBook request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId, cancellationToken);

        if (book is null)
            return new EditBookResponse("No book found");

        book.Title = request.Title;
        book.Description = request.Description;
        book.AuthorId = request.AuthorId;
        book.CategoryId = request.CategoryId;

        return new EditBookResponse();
    }
}
