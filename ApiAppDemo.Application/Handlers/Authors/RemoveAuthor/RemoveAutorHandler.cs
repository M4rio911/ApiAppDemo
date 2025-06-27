using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;

namespace ApiAppDemo.Application.Handlers.Authors.RemoveAuthor;

public class RemoveAuthorHandler : ICommandHandler<RemoveAuthor, RemoveAuthorResponse>
{
    private readonly IAuthorRepository _authorRepository;

    public RemoveAuthorHandler(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<RemoveAuthorResponse> Handle(RemoveAuthor request, CancellationToken cancellationToken)
    {
        await _authorRepository.RemoveAsync(request.AuthorId, cancellationToken);

        return new RemoveAuthorResponse();
    }
}
