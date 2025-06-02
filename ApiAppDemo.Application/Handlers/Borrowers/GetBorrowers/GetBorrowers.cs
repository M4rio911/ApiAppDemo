using static ApiAppDemo.Application.Interfaces.MediatR.ICommand;

namespace ApiAppDemo.Application.Handlers.Borrowers.GetBorrowers;

public class GetBorrowers : ICommand<GetBorrowersResponse>
{
    public GetBorrowers()
    {

    }
}