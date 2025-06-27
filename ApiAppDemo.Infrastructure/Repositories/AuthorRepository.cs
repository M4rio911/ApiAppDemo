using ApiAppDemo.Application.Dto.Books;
using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ApiAppDemo.Infrastructure.Repositories;

public class AuthorRepository : AppDbContextFactory, IAuthorRepository
{
    private readonly AppDbContext _context;
    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Author> AddAsync(Author book, CancellationToken token)
    {
        _context.Authors.Add(book);
        _context.SaveChangesAsync(token);
        return book;
    }

    public async Task DeleteAsync(int id, CancellationToken token)
    {
        var author = await _context.Authors
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(token);
        if (author != null)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync(token);
        }
    }

    public async Task<Author> EditAsync(EditAuthorDto book, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Author>> GetAuthorsAsync(CancellationToken token)
    {
        return await _context.Authors
            .ToListAsync(token);
    }

    public async Task<Author> GetByIdAsync(int id, CancellationToken token)
    {
        return await _context.Authors
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(token);
    }

    public async Task<bool> RemoveAsync(int authorId, CancellationToken cancellationToken)
    {

        var author = await _context.Authors
            .Where(x => x.Id == authorId)
            .FirstOrDefaultAsync(cancellationToken);

        if (author != null)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        return false;
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
