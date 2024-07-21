using Serilog;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Remove all providers
builder.Logging.ClearProviders();
// Add Console Logging Provider
builder.Logging.AddConsole();
// Add Debug Logging Provider (not working as expected)
builder.Logging.AddDebug();

// // Use Serilog to save log to file 
// // (Automatically generate log file in bin/Debug/net8.0/logs/{logfile}.txt)
// var logger = new LoggerConfiguration()
// .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/log.txt"), rollingInterval: RollingInterval.Day, retainedFileCountLimit: 90)
// .CreateLogger();

// Use Serilog to format console log message to JSON
var logger = new LoggerConfiguration()
.WriteTo.Console(new JsonFormatter())
.CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
