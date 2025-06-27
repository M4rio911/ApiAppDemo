using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Books.AddBook;

public class AddBookHandler : ICommandHandler<AddBook, AddBookResponse>
{
    private readonly IBookRepository _bookRepository;

    public AddBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<AddBookResponse> Handle(AddBook request, CancellationToken cancellationToken)
    {
        var newBook = new Book
        {
            AuthorId = request.AuthorId,
            CategoryId = request.CategoryId,
            Title = request.Title,
            Description = request.Description,
            IsBorrowed = false
        };

        await _bookRepository.AddAsync(newBook, cancellationToken);

        return new AddBookResponse();
    }
}
