using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

var services = new ServiceCollection();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/app-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

services.AddLogging(builder =>
{
    builder.ClearProviders();
    builder.AddSerilog(Log.Logger);
});

services.AddScoped<UserService>();

var provider = services.BuildServiceProvider();

var userService = provider.GetRequiredService<UserService>();

userService.CreateUser("John");

Log.CloseAndFlush();


public class UserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public void CreateUser(string name)
    {
        _logger.LogInformation("Creating user: {Name}", name);

        try
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Invalid name");

            _logger.LogInformation("User {Name} created successfully", name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create user: {Name}", name);
        }
    }
}
