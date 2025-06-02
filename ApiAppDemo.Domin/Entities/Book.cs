using ApiAppDemo.Domain.Common;

namespace ApiAppDemo.Domin.Entities;

public class Book : AuditableEntity
{
    public int Id { get; set; }
    public Author Author { get; set; }
    public int AuthorId { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Borrower? Borrower { get; set; }
    public int? BorrowerId { get;set; }
}
