using System;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.CircuitBreaker;
using Polly.Timeout;

HttpClient client = new HttpClient();

await CircuitBreakerDemo();

Console.ReadKey();

async Task CircuitBreakerDemo()
{
    var circuitBreakerPolicy = Policy
        .Handle<HttpRequestException>()
        .CircuitBreakerAsync(
            exceptionsAllowedBeforeBreaking: 2,
            durationOfBreak: TimeSpan.FromSeconds(10),
            onBreak: (ex, breakDelay) =>
            {
                Console.WriteLine($"State: OPEN. Circuit broken for {breakDelay.TotalSeconds} seconds.");
            },
            onReset: () =>
            {
                Console.WriteLine("State: CLOSED. Circuit reset.");
            },
            onHalfOpen: () =>
            {
                Console.WriteLine("State: HALF-OPEN. Testing service...");
            });

    for (int i = 0; i < 10; i++)
    {
        try
        {
            await circuitBreakerPolicy.ExecuteAsync(async () =>
            {
                Console.WriteLine("Calling external service...");
                Console.WriteLine($"Time: {DateTime.Now}");

                var result = await CallExternalService();
                Console.WriteLine($"Result: {result}");
            });

            Console.WriteLine("Request successful.");
        }
        catch (BrokenCircuitException)
        {
            Console.WriteLine("Circuit is OPEN. Request blocked.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request failed: {ex.Message}");
        }

        await Task.Delay(1000);
    }
}

async Task<string> CallExternalService()
{
    var response = await client.GetAsync("http://localhost:5000/customer");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadAsStringAsync();
}