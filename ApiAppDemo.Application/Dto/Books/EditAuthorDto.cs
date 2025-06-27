using ApiAppDemo.Application.Handlers.Books.EditBook;

namespace ApiAppDemo.Application.Dto.Books;

public class EditAuthorDto
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? BorrowerId { get; set; }
    public EditAuthorDto(EditBook book)
    {
        BookId = book.BookId;
        AuthorId = book.AuthorId;
        CategoryId = book.CategoryId;
        Title = book.Title;
        Description = book.Description;
        BorrowerId = book.BorrowerId;
    }
}
