public class Proposal
{
    public Guid Id { get; set; }
    public required string Detail { get; set; }
    public required double Price { get; set; }
    public DateTime? CreatAt { get; set; } = DateTime.Now;
    public Guid ProjectId { get; set; }
    public Guid UserId { get; set; }
    
}