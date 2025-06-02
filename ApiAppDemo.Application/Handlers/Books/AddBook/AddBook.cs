using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Books.AddBook;

public class AddBook : ICommand<AddBookResponse>
{
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public AddBook(AddBookParameters parameters)
    {
        AuthorId = parameters.AuthorId;
        CategoryId = parameters.CategoryId;
        Title = parameters.Title;
        Description = parameters.Description;
    }
}