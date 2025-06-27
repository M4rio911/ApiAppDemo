namespace ApiAppDemo.Application.Dto.Borrowers;

public class BorrowerDto
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}
