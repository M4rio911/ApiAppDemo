using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Authors.RemoveAuthor;

public class RemoveAuthor : ICommand<RemoveAuthorResponse>
{
    public int AuthorId { get; set; }

    public RemoveAuthor(RemoveAuthorParameters parameters)
    {
        AuthorId = parameters.AuthorId;
    }
}