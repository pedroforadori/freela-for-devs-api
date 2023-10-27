using Microsoft.EntityFrameworkCore;

public static class ProposalEndPoint
{
    public static void MapProposalEndpoint(this WebApplication app)
    {

        app.MapGet("/proposal", async (AppDbContext context) =>
            await context.Proposals.ToListAsync()
        );

        app.MapGet("/proposal/{id}", async (Guid id, AppDbContext context) =>
            await context.Proposals.FindAsync(id) is Proposal proposal
                    ? Results.Ok(proposal)
                    : Results.NotFound()
        );

        app.MapPost("/proposal", async (Proposal proposal, AppDbContext context) =>
        {
            var proposalExists = (from x in context.Proposals where x.UserId == proposal.UserId select x).FirstOrDefault();
            var error = new { errorMessage = "Proposta já foi enviada" };

            if (proposalExists != null)
            {
                return Results.NotFound(error);
            }
            else
            {
                context.Proposals.Add(proposal);
                await context.SaveChangesAsync();

                return Results.Created($"/proposal/{proposal.Id}", proposal);
            }
        });

        app.MapPut("/proposal/{id}", async (Guid id, Proposal inputProposal, AppDbContext context) =>
        {
            var proposal = await context.Proposals.FindAsync(id);

            if (proposal is null) return Results.NotFound();

            proposal.Price = inputProposal.Price;

            await context.SaveChangesAsync();
            return Results.Ok(proposal);
        });

        app.MapDelete("/proposal/{id}", async (Guid id, AppDbContext context) =>
        {
            if (await context.Proposals.FindAsync(id) is Proposal proposal)
            {
                context.Remove(proposal);
                await context.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });
    }
}