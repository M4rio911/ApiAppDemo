using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Books.RemoveBook;

public class RemoveBook : ICommand<RemoveBookResponse>
{
    public int BookId { get; set; }

    public RemoveBook(RemoveBookParameters parameters)
    {
        BookId = parameters.BookId;
    }
}