using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Borrowers.GetBorrower;

public class GetBorrower : ICommand<GetBorrowerResponse>
{
    public int BorrowerId { get; set; }

    public GetBorrower(GetBorrowerParameters parameters)
    {
        BorrowerId = parameters.BorrowerId;
    }
}