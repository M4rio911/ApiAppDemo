using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Books.GetBooks;

public class GetBooks : ICommand<GetBooksResponse>
{
    public GetBooks()
    {

    }
}