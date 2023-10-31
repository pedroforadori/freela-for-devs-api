using Microsoft.EntityFrameworkCore;

public static class UseAuthEndPoint
{
    public static void MapAuthEndpoint(this WebApplication app)
    {
        app.MapPost("/auth", (User user, AppDbContext context) =>
        {
            var userAuth = (from x in context.Users
                            where x.Email == user.Email && x.Password == user.Password
                            select x).FirstOrDefault();

            var returnUser = new
            {
                errorMessage = false,
                loginMessage = "Logado"
            };

            if (userAuth != null)
            {
                return Results.Ok(userAuth);
            }
            else
            {
                return Results.Ok(returnUser.errorMessage);
            }
        });

    }
}