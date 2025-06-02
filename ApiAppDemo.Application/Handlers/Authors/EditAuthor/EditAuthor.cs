using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Authors.EditAuthor;

public class EditAuthor : ICommand<EditAuthorResponse>
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public EditAuthor(EditAuthorParameters parameters)
    {
        AuthorId = parameters.AuthorId;
        FirstName = parameters.FirstName;
        LastName = parameters.LastName;
    }
}