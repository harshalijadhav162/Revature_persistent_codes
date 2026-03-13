using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add Redis cache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379"; // Memurai default port
});

builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.Run();