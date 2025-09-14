var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => new
{
    Message = "Welcome to the Updated Weather App! 🌤️",
    Version = "1.1.0",
    Environment = app.Environment.EnvironmentName,
    Timestamp = DateTime.UtcNow,
    DeployedBy = "GitHub Actions"
});

app.Run();