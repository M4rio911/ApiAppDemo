namespace ApiAppDemo.Application.Handlers.Books.AddBook;

public class AddBookParameters
{
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}