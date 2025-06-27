using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Domin.Entities;

namespace ApiAppDemo.Application.Handlers.Borrowers.AddBorrower;

public class AddBorrowerHandler : ICommandHandler<AddBorrower, AddBorrowerResponse>
{
    private readonly IBorrowerRepository _borrowerRepository;
    public AddBorrowerHandler(IBorrowerRepository borrowerRepository)
    {
        _borrowerRepository = borrowerRepository;
    }

    public async Task<AddBorrowerResponse> Handle(AddBorrower request, CancellationToken cancellationToken)
    {

        var newBorrower = new Borrower
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.DateOfBirth,
            CreatedBy = "test",
            ModifiedBy = "test"
        };

        var dbBorrower = await _borrowerRepository.AddAsync(newBorrower, cancellationToken);

        return new AddBorrowerResponse();
    }
}
