//public record User(Guid Id, string Fullname, string Email, string Password);

public enum EType
{
    Freelancer,
    Client
}
public class User
{
    public Guid Id { get; set; }
    public string? Fullname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required EType Type { get; set; }
    public ICollection<Project>? Projects { get; } = new List<Project>();
}