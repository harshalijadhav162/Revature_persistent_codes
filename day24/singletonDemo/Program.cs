using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<DiSingleton>();

var serviceProvider = services.BuildServiceProvider();

var diLogger1 = serviceProvider.GetService<DiSingleton>();
var diLogger2 = serviceProvider.GetService<DiSingleton>();

var loggerManual = new DiSingleton();

Console.WriteLine(diLogger1.GetHashCode());
Console.WriteLine(diLogger2.GetHashCode());
Console.WriteLine(loggerManual.GetHashCode());

public class DiSingleton
{
    public int Value { get; set; }
}
