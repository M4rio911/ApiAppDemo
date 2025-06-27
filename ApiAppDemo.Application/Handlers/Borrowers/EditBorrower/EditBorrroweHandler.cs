using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiAppDemo.Application.Handlers.Borrowers.EditBorrower;

public class EditBorrroweHandler : ICommandHandler<EditBorrower, EditBorrowerResponse>
{
    private readonly IBorrowerRepository _borrowerRepository;
    public EditBorrroweHandler(IBorrowerRepository borrowerRepository)
    {
        _borrowerRepository = borrowerRepository;
    }

    public async Task<EditBorrowerResponse> Handle(EditBorrower request, CancellationToken cancellationToken)
    {
        var dbBorrower = await _borrowerRepository.GetByIdAsync(request.BorrowerId, cancellationToken);

        dbBorrower.ModifiedBy = "test";
        dbBorrower.FirstName = request.FirstName;
        dbBorrower.LastName = request.LastName;
        dbBorrower.BirthDate = request.DateOfBirth;

        if (dbBorrower is null)
            return new EditBorrowerResponse("No borrower found");

        await _borrowerRepository.SaveChangesAsync(cancellationToken);

        return new EditBorrowerResponse();
    }
}
