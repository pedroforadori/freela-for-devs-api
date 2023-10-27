var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

app.MapGet("/", () => "API ON");

app.MapUserEndpoint();
app.MapAuthEndpoint();
app.MapProjectEndpoint();

app.Run();

