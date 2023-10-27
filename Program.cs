var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.MapGet("/", () => "API ON");
app.MapUserEndpoint();
app.MapAuthEndpoint();
app.MapProjectEndpoint();
app.MapProposalEndpoint();
app.MapProposalProjectEndpoint();

app.Run();

