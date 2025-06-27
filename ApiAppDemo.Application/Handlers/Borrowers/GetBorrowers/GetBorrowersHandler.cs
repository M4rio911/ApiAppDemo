using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApiAppDemo.Application.Handlers.Borrowers.GetBorrowers;

public class GetBorrowersHandler : ICommandHandler<GetBorrowers, GetBorrowersResponse>
{
    private readonly IBorrowerRepository _borrowerRepository;
    public GetBorrowersHandler(IBorrowerRepository borrowerRepository)
    {
        _borrowerRepository = borrowerRepository;
    }

    public async Task<GetBorrowersResponse> Handle(GetBorrowers request, CancellationToken cancellationToken)
    {
        var dbBorrowers = await _borrowerRepository.GetBorrowersAsync(cancellationToken);

        return new GetBorrowersResponse() { Borrowers = dbBorrowers };
    }
}