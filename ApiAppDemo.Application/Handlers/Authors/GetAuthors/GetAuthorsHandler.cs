using ApiAppDemo.Application.Dto.Authors;
using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Authors.GetAuthors;

public class GetAuthorsHandler : ICommandHandler<GetAuthors, GetAuthorsResponse>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorsHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<GetAuthorsResponse> Handle(GetAuthors request, CancellationToken cancellationToken)
    {
        var dbAuthors = await _authorRepository.GetAuthorsAsync(cancellationToken);

        var authorDtos = dbAuthors
        .Select(a => new AuthorDto
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName,
            BirthDate = a.BirthDate
        })
        .ToList();

        return new GetAuthorsResponse
        {
            Authors = authorDtos
        };
    }
}
