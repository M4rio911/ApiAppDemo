using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Books.ReturnBook;

public class ReturnBook : ICommand<ReturnBookResponse>
{
    public int BookId { get; set; }

    public ReturnBook(ReturnBookParameters parameters)
    {
        BookId = parameters.BookId;
    }
}