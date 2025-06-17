using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Books.GetBook;

public class GetBook : ICommand<GetBookResponse>
{
    public int Id { get; set; }

    public GetBook(GetBookParameters parameters)
    {
        Id = parameters.Id;
    }
}