using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Books.BorrowBook;

public class BorrowBook : ICommand<BorrowBookResponse>
{
    public int BookId { get; set; }
    public int BorrowerId { get; set; }

    public BorrowBook(BorrowBookParameters parameters)
    {
        BookId = parameters.BookId;
        BorrowerId = parameters.BorrowerId;
    }
}