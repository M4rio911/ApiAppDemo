using ApiAppDemo.Application.Dto.Borrowers;
using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;

namespace ApiAppDemo.Application.Handlers.Borrowers.GetBorrower;

public class GetBorrowerHandler : ICommandHandler<GetBorrower, GetBorrowerResponse>
{
    private readonly IBorrowerRepository _borrowerRepository;
    public GetBorrowerHandler(IBorrowerRepository borrowerRepository)
    {
        _borrowerRepository = borrowerRepository;
    }

    public async Task<GetBorrowerResponse> Handle(GetBorrower request, CancellationToken cancellationToken)
    {
        var dbBorrower = await _borrowerRepository.GetByIdAsync(request.BorrowerId, cancellationToken);

        if (dbBorrower is null)
            return new GetBorrowerResponse("No borrower found");

        var borrowerDto = new BorrowerDto
        {
            Id = dbBorrower.Id,
            FirstName = dbBorrower.FirstName,
            LastName = dbBorrower.LastName,
            BirthDate = dbBorrower.BirthDate
        };

        return new GetBorrowerResponse() { Borrower = borrowerDto };
    }
}
