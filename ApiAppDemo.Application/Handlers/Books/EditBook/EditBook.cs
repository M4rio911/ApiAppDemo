using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Books.EditBook;

public class EditBook : ICommand<EditBookResponse>
{
    public int BookId { get; set; }
    public int? BorrowerId { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public EditBook(EditBookParameters parameters)
    {
        BookId = parameters.BookId;
        BorrowerId = parameters.BorrowerId;
        AuthorId = parameters.AuthorId;
        CategoryId = parameters.CategoryId;
        Title = parameters.Title;
        Description = parameters.Description;
    }
}