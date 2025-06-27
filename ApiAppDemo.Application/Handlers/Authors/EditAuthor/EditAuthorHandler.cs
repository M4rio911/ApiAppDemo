using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Authors.EditAuthor;

public class EditAuthorHandler : ICommandHandler<EditAuthor, EditAuthorResponse>
{
    private readonly IAuthorRepository _authorRepository;

    public EditAuthorHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<EditAuthorResponse> Handle(EditAuthor request, CancellationToken cancellationToken)
    {
        var dbAuthor = await _authorRepository.GetByIdAsync(request.AuthorId, cancellationToken);

        if (dbAuthor is null)
            return new EditAuthorResponse("No author found");

        dbAuthor.ModifiedBy = "test";
        dbAuthor.FirstName = request.FirstName;
        dbAuthor.LastName = request.LastName;
        dbAuthor.BirthDate = request.DateOfBirth;

        await _authorRepository.SaveChangesAsync(cancellationToken);

        return new EditAuthorResponse();
    }
}
