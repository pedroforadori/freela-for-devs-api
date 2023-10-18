//public record User(Guid Id, string Fullname, string Email, string Password);

public class User
{
    public Guid Id { get; set; }
    public required string Fullname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}