using ApiAppDemo.Application.Interfaces.MediatR;
using ApiAppDemo.Application.Interfaces.Repositories;

namespace ApiAppDemo.Application.Handlers.Books.BorrowBook;

public class BorrowBookHandler : ICommandHandler<BorrowBook, BorrowBookResponse>
{
    private readonly IBookRepository _bookRepository;
    private readonly IBorrowerRepository _borrowerRepository;
    public BorrowBookHandler(IBookRepository bookRepository, IBorrowerRepository borrowerRepository)
    {
        _bookRepository = bookRepository;
        _borrowerRepository = borrowerRepository;
    }

    public async Task<BorrowBookResponse> Handle(BorrowBook request, CancellationToken cancellationToken)
    {
        var dbBook = await _bookRepository.GetByIdAsync(request.BookId, cancellationToken);
        if (dbBook == null)
        {
            return new BorrowBookResponse("Book with passed Id does not exists");
        }

        var dbBorrower = await _borrowerRepository.GetByIdAsync(request.BorrowerId, cancellationToken);
        if (dbBorrower == null) 
        { 
            return new BorrowBookResponse("Borrower with passed Id does not exists"); 
        }

        if (dbBook.IsBorrowed)
        {
            return new BorrowBookResponse("Book is already borrowed");
        }

        await _bookRepository.BorrowBook(request.BookId, request.BorrowerId, cancellationToken);

        return new BorrowBookResponse();
    }
}
