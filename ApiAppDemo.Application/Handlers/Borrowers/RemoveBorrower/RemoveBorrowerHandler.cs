using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Borrowers.RemoveBorrower;

public class RemoveBorrowerHandler : ICommandHandler<RemoveBorrower, RemoveBorrowerResponse>
{
    private readonly IBorrowerRepository _borrowerRepository;
    public RemoveBorrowerHandler(IBorrowerRepository borrowerRepository)
    {
        _borrowerRepository = borrowerRepository;
    }

    public async Task<RemoveBorrowerResponse> Handle(RemoveBorrower request, CancellationToken cancellationToken)
    {
        var dbBorrower = await _borrowerRepository.GetByIdAsync(request.BorrowerId, cancellationToken);

        if (dbBorrower == null)
        {
            return new RemoveBorrowerResponse("Catergory with passed Id does not exists");
        }

        await _borrowerRepository.RemoveBorrower(dbBorrower.Id, cancellationToken);

        return new RemoveBorrowerResponse();
    }
}
