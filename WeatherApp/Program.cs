app.MapGet("/", () => new
{
    Message = "Welcome to the Updated Weather App! 🌤️",
    Version = "1.1.0",
    Environment = app.Environment.EnvironmentName,
    Timestamp = DateTime.UtcNow,
    DeployedBy = "GitHub Actions"
})