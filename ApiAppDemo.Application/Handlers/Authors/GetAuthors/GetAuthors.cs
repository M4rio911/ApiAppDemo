using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Authors.GetAuthors;

public class GetAuthors : ICommand<GetAuthorsResponse>
{
    public GetAuthors()
    {

    }
}