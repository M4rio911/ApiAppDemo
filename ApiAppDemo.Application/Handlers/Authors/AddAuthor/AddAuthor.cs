using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Authors.AddAuthor;

public class AddAuthor : ICommand<AddAuthorResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public AddAuthor(AddAuthorParameters parameters)
    {
        FirstName = parameters.FirstName;
        LastName = parameters.LastName;
        DateOfBirth = parameters.DateOfBirth;
    }
}