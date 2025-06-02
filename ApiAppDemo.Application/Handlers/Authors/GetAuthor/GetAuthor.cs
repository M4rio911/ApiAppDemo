using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Authors.GetAuthor;

public class GetAuthor : ICommand<GetAuthorResponse>
{
    public int AuthorId { get; set; }

    public GetAuthor(GetAuthorParameters parameters)
    {
        AuthorId = parameters.AuthorId;
    }
}