using ApiAppDemo.Application.Dto.Authors;
using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;

namespace ApiAppDemo.Application.Handlers.Authors.GetAuthor;

public class GetAuthorHandler : ICommandHandler<GetAuthor, GetAuthorResponse>
{
    private readonly IAuthorRepository _authorRepository;

    public GetAuthorHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<GetAuthorResponse> Handle(GetAuthor request, CancellationToken cancellationToken)
    {
        var dbAuthor = await _authorRepository.GetByIdAsync(request.AuthorId, cancellationToken);

        if (dbAuthor is null)
            return new GetAuthorResponse("No author found");

        var authorDto = new AuthorDto
        {
            Id = dbAuthor.Id,
            FirstName = dbAuthor.FirstName,
            LastName = dbAuthor.LastName,
            BirthDate = dbAuthor.BirthDate
        };

        return new GetAuthorResponse() { Author = authorDto };
    }
}
