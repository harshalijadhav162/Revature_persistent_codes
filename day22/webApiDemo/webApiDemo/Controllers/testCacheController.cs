using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

[ApiController]
[Route("[controller]")]
public class TestCacheController : ControllerBase
{
    private readonly IDistributedCache _cache;

    public TestCacheController(IDistributedCache cache)
    {
        _cache = cache;
    }

    [HttpGet("set")]
    public async Task<IActionResult> SetCache()
    {
        await _cache.SetStringAsync("Message", "Hello Redis!");
        return Ok("Value set in Redis");
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetCache()
    {
        var value = await _cache.GetStringAsync("Message");
        return Ok(value ?? "No value found");
    }
}