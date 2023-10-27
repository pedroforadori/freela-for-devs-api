using Microsoft.EntityFrameworkCore;

public static class ProposalProjectEndPoint
{
    public static void MapProposalProjectEndpoint(this WebApplication app)
    {
        app.MapGet("/project/{id}/proposal", (Guid id, AppDbContext context) =>
        {
            var project = from Project in context.Set<Project>()
                          join Proposal in context.Set<Proposal>()
                          on Project.Id equals Proposal.ProjectId
                          select new { Proposal };

            return project;

        });
    }
}