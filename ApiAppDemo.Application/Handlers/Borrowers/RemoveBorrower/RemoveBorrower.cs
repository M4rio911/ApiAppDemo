using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Borrowers.RemoveBorrower;

public class RemoveBorrower : ICommand<RemoveBorrowerResponse>
{
    public int BorrowerId { get; set; }

    public RemoveBorrower(RemoveBorrowerParameters parameters)
    {
        BorrowerId = parameters.BorrowerId;
    }
}