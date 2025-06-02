namespace ApiAppDemo.Application.Handlers.Books.EditBook;

public class EditBookParameters
{
    public int BookId { get; set; }
    public int? BorrowerId { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}