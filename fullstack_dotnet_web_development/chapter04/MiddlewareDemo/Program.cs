using System.Net;
using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using MiddlewareDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Declare Rate Limiter
builder.Services.AddRateLimiter(_ => _.AddFixedWindowLimiter(policyName: "fixed", options =>
{
    options.PermitLimit = 5;
    options.Window = TimeSpan.FromSeconds(10);
    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    options.QueueLimit = 2;
}));

// Declare Request Timeout (No Policy)
// builder.Services.AddRequestTimeouts();

// Declare Request Timeout (With Policy)
builder.Services.AddRequestTimeouts(option =>
{
    option.DefaultPolicy = new Microsoft.AspNetCore.Http.Timeouts.RequestTimeoutPolicy { Timeout = TimeSpan.FromSeconds(5) };
    option.AddPolicy("ShortTimeoutPolicy", TimeSpan.FromSeconds(2));
    option.AddPolicy("LongTimeoutPolicy", TimeSpan.FromSeconds(10));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/*
    CODE IN EXAMPLE FOLDER PLACEHOLDER
*/

// Add Rate Limiter Middleware
app.UseRateLimiter();
// Minimal API Request for Rate Limiter demo
app.MapGet(
    "/rate-limiting-mini", 
    () => Results.Ok($"Hello {DateTime.Now.Ticks.ToString()}")
).RequireRateLimiting("fixed");

// Add Request Timeouts middleware
app.UseRequestTimeouts();
// Minimal API Request for Request Timeouts demo
app.MapGet(
    "/request-timeout-mini",
    async (HttpContext context, ILogger<Program> logger) =>
    {
        var random = new Random();
        var delay = random.Next(1, 10);
        logger.LogInformation($"Delay for {delay} seconds");
        try
        {
            await Task.Delay(TimeSpan.FromSeconds(delay), context.RequestAborted);
        }
        catch
        {
            logger.LogWarning("The request timed out");
            return Results.Content("The request timed out", "text/plain");
        }
        return Results.Content($"Hello! The task is completed in {delay} seconds", "text/plain");
    }
).WithRequestTimeout(TimeSpan.FromSeconds(5));

// Short circuit middleware (request don't need to enter the server)
// app.MapGet("robots.txt", () => Results.Content("User-agent: *\nDisallow: /", "text/plain")).ShortCircuit();
app.MapShortCircuit((int)HttpStatusCode.NotFound, "robots.txt", "favicon.ico");

// // Example of custom middleware (correlation ID middleware)
app.UseCorrelationId();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
