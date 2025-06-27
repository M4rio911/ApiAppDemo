using ApiAppDemo.Application.Interfaces.Repositories;
using ApiAppDemo.Domin.Entities;
using ApiAppDemo.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ApiAppDemo.Infrastructure.Repositories;

public class CategoryRepository : AppDbContextFactory, ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Category> AddAsync(Category category, CancellationToken token)
    {
        _context.Categories.Add(category);
        _context.SaveChangesAsync(token);
        return category;
    }

    public async Task DeleteAsync(int id, CancellationToken token)
    {
        var category = await _context.Categories
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(token);
        }
    }

    public async Task<Category> EditAsync(Category category, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> GetByIdAsync(int id, CancellationToken token)
    {
        return await _context.Categories
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(token);
    }

    public async Task<List<Category>> GetCategoriesAsync(CancellationToken token)
    {
        return await _context.Categories
            .ToListAsync(token);
    }

    public Task<bool> RemoveCategory(int categoryId, CancellationToken cancellationToken)
    {
        var category = _context.Categories
            .Where(x => x.Id == categoryId)
            .FirstOrDefaultAsync(cancellationToken);

        if (category != null)
        {
            _context.Categories.Remove(category.Result);
            return _context.SaveChangesAsync(cancellationToken)
                .ContinueWith(t => true, cancellationToken);
        }
        return Task.FromResult(false);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
