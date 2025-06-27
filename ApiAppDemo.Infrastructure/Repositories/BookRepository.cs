using ApiAppDemo.Application.Dto.Books;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ApiAppDemo.Infrastructure.Repositories;

public class BookRepository : AppDbContextFactory, IBookRepository
{
    private readonly AppDbContext _context;
    public BookRepository(AppDbContext context)
    {
        _context = context;
    }
    async public Task<Book> AddAsync(Book book, CancellationToken cancellationToken)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync(cancellationToken);

        return book;
    }

    public Task<bool> BorrowBook(int bookId, int borrowerId, CancellationToken cancellationToken)
    {
        var book = _context.Books
            .Where(x => x.Id == bookId)
            .FirstOrDefaultAsync(cancellationToken);

        if (book != null)
        {
            book.Result.IsBorrowed = true;
            book.Result.BorrowerId = borrowerId;
            book.Result.ModifiedBy = "test";
            return _context.SaveChangesAsync(cancellationToken).ContinueWith(t => true, cancellationToken);
        }

        return Task.FromResult(false);
    }

    public Task DeleteAsync(int id, CancellationToken token)
    {
        var book = _context.Books
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(token);

        if (book != null)
        {
            _context.Books.Remove(book.Result);
            return _context.SaveChangesAsync(token);
        }
        return Task.CompletedTask;
    }

    public async Task<Book> EditAsync(EditBookDto book, CancellationToken cancellationToken)
    {
        var dbBook = await _context.Books
            .Where(x => x.Id == book.BookId)
            .FirstOrDefaultAsync(cancellationToken);

        dbBook.ModifiedBy = "test";
        dbBook.AuthorId = book.AuthorId;
        dbBook.CategoryId = book.CategoryId;
        dbBook.BorrowerId = book.BorrowerId;
        dbBook.Description = book.Description;
        dbBook.Title = book.Title;

        await _context.SaveChangesAsync(cancellationToken);

        return dbBook;
    }

    public async Task<List<Book>> GetBooksAsync(CancellationToken token)
    {
        return await _context.Books.ToListAsync(token);
    }

    public async Task<Book> GetByIdAsync(int id, CancellationToken token)
    {
        return await _context.Books
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(token);
    }

    public Task<Book> RemoveBook(int bookId, CancellationToken cancellationToken)
    {
        var book = _context.Books
            .Where(x => x.Id == bookId)
            .FirstOrDefaultAsync(cancellationToken);
        if (book != null)
        {
            _context.Books.Remove(book.Result);
            return _context.SaveChangesAsync(cancellationToken).ContinueWith(t => book.Result, cancellationToken);
        }
        return Task.FromResult<Book>(null);

    }

    public Task<bool> ReturnBook(int bookId, CancellationToken cancellationToken)
    {
        var book = _context.Books
            .Where(x => x.Id == bookId)
            .FirstOrDefaultAsync(cancellationToken);

        if (book != null)
        {
            book.Result.IsBorrowed = false;
            book.Result.BorrowerId = null;
            book.Result.ModifiedBy = "test";
            return _context.SaveChangesAsync(cancellationToken).ContinueWith(t => true, cancellationToken);
        }
        return Task.FromResult(false);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
