using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Authors.AddAuthor;

public class AddAuthorHandler : ICommandHandler<AddAuthor, AddAuthorResponse>
{
    private readonly IAuthorRepository _authorRepository;

    public AddAuthorHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<AddAuthorResponse> Handle(AddAuthor request, CancellationToken cancellationToken)
    {
        var newAuthor = new Author
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.DateOfBirth,
            CreatedBy = "admin",
            ModifiedBy = "admin"
        };

        var createdAuthor = await _authorRepository.AddAsync(newAuthor, cancellationToken);

        return new AddAuthorResponse();
    }
}
