using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Borrowers.EditBorrower;

public class EditBorrower : ICommand<EditBorrowerResponse>
{
    public int BorrowerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }

    public EditBorrower(EditBorrowerParameters parameters)
    {
        BorrowerId = parameters.BorrowerId;
        FirstName = parameters.FirstName;
        LastName = parameters.LastName;
        DateOfBirth = parameters.DateOfBirth;
    }
}