using ApiAppDemo.Domain.Common;
using ApiAppDemo.Domin.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace ApiAppDemo.Persistance;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Borrower> Borrowers { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Book>(entity =>
        {
            entity.HasKey(p => p.Id);
        });

        builder.Entity<Author>(entity =>
        {
            entity.HasKey(p => p.Id);
        });

        builder.Entity<Category>(entity =>
        {
            entity.HasKey(p => p.Id);
        });

        builder.Entity<Borrower>(entity =>
        {
            entity.HasKey(p => p.Id);
        });

        builder.Entity<Book>()
            .HasOne(c => c.Author)
            .WithMany()
            .HasForeignKey(l => l.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Book>()
            .HasOne(c => c.Borrower)
            .WithMany()
            .HasForeignKey(l => l.BorrowerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Book>()
            .HasOne(c => c.Category)
            .WithMany()
            .HasForeignKey(l => l.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;

                    break;
                case EntityState.Modified:
                    entry.Entity.Modified = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    public Task<int> SaveChangesWithAuditableEntityAsync(IHttpContextAccessor _httpContextAccessor, CancellationToken cancellationToken = default)
    {
        //var user = _httpContextAccessor.HttpContext.User.Identity.Name;
        var user = "test";

        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = user;
                    entry.Entity.Created = DateTime.UtcNow;

                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedBy = user;
                    entry.Entity.Modified = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
