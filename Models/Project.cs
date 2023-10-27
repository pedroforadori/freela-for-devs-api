public enum ESpecialty
{
    Frontend,
    Backend,
    Fullstack
}

public class Project
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string DescriptionProject { get; set; }
    public required double Budget { get; set; }
    public ESpecialty? Specialty { get; set; }
    public DateTime? CreatAt { get; set; } = DateTime.Now;
    public Guid UserId { get; set; }
    public ICollection<Proposal>? Proposals { get; } = new List<Proposal>();
}