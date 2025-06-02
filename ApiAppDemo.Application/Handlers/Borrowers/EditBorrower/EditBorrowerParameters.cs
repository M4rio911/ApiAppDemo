namespace ApiAppDemo.Application.Handlers.Borrowers.EditBorrower;

public class EditBorrowerParameters
{
    public int BorrowerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}