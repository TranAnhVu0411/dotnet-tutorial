using DependencyInjectionExample.Services;
using DependencyInjectionExample.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDemoService, DemoService>(); // Using Scoped
// builder.Services.AddSingleton<IDemoService, DemoService>(); // Using Singleton

// Register services separately
// builder.Services.AddScoped<IScopedService, ScopedService>(); // Using Scoped
// builder.Services.AddTransient<ITransientService, TransientService>(); // Using Transient
// builder.Services.AddSingleton<ISingletonService, SingletonService>(); // Using Singleton

// Instead of registering each service in Program.cs, 
// we use IServiceCollection interface to register all service at once
builder.Services.AddLifeTimeServices();

// Using named services (register services with a key)
builder.Services.AddKeyedScoped<IDataService, SqlDatabaseService>("sqlDatabaseService");
builder.Services.AddKeyedScoped<IDataService, CosmoDatabaseService>("cosmoDatabaseService");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Resolving a service when the app starts
using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var demoService = services.GetRequiredService<IDemoService>();
    var message = demoService.SayHello();
    Console.WriteLine(message);
}

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
