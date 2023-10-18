using Microsoft.EntityFrameworkCore;

public static class UserEndPoint{
    public static void MapUserEndpoint (this WebApplication app){
        
    app.MapGet("/user", async (AppDbContext context) =>
        await context.Users.ToListAsync());

    app.MapGet("/user/{id}", async (Guid id, AppDbContext context) =>
        await context.Users.FindAsync(id) is User user
                ? Results.Ok(user)
                : Results.NotFound());

    app.MapPost("/user", async (User user, AppDbContext context) =>
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();

        return Results.Created($"/user/{user.Id}", user);
    });

    app.MapPut("/user/{id}", async (Guid id, User inputUser, AppDbContext context) =>
    {
        var user = await context.Users.FindAsync(id);

        if (user is null) return Results.NotFound();
        
        user.Fullname = inputUser.Fullname;
        user.Email = inputUser.Email;
        user.Password = inputUser.Password;

        await context.SaveChangesAsync();

        return Results.Ok(user);
    });

    app.MapDelete("/user/{id}", async (Guid id, AppDbContext context) =>
    {
        if (await context.Users.FindAsync(id) is User user)
        {
            context.Remove(user);
            await context.SaveChangesAsync();
            return Results.NoContent();
        }

        return Results.NotFound();
    });
    }
}