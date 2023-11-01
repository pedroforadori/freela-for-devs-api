using Microsoft.EntityFrameworkCore;

public static class ProjectEndPoint
{
    public static void MapProjectEndpoint(this WebApplication app)
    {

        app.MapGet("/project", async (AppDbContext context) =>
            await context.Projects.ToListAsync()
        );

        app.MapGet("/project/{id}", async (Guid id, AppDbContext context) =>
            await context.Projects.FindAsync(id) is Project project
                    ? Results.Ok(project)
                    : Results.NotFound()
        );

        app.MapGet("/project/user/{id}", async (Guid id, AppDbContext context) =>
        {
            var project = context.Projects
                            .Where(p => p.UserId == id)
                            .ToList();

            return project;
        });

        app.MapPost("/project", async (Project project, AppDbContext context) =>
        {
            context.Projects.Add(project);
            await context.SaveChangesAsync();

            return Results.Created($"/project/{project.Id}", project);

        });

        app.MapPut("/project/{id}", async (Guid id, Project inputProject, AppDbContext context) =>
        {
            var project = await context.Projects.FindAsync(id);

            if (project is null) return Results.NotFound();

            project.DescriptionProject = inputProject.DescriptionProject;
            project.Budget = inputProject.Budget;
            project.Specialty = inputProject.Specialty;

            await context.SaveChangesAsync();
            return Results.Ok(project);
        });

        app.MapDelete("/project/{id}", async (Guid id, AppDbContext context) =>
        {
            if (await context.Projects.FindAsync(id) is Project project)
            {
                context.Remove(project);
                await context.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });
    }
}