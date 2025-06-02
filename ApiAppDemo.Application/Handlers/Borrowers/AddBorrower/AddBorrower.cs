using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Borrowers.AddBorrower;

public class AddBorrower : ICommand<AddBorrowerResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public AddBorrower(AddBorrowerParameters parameters)
    {
        FirstName = parameters.FirstName;
        LastName = parameters.LastName;
        DateOfBirth = parameters.DateOfBirth;
    }
}