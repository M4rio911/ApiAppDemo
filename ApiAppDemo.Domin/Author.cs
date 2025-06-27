using ApiAppDemo.Domain.Common;

namespace ApiAppDemo.Domin.Entities;

public class Author : AuditableEntity
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime BirthDate { get; set; }
}
