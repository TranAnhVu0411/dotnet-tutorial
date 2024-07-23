using ConcurrencyConflictDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SampleDbContext>();

// Reset the database 
// (Another way to create the database without using migration)
// Uncomment (1) and comment (2) + dotnet run => Create db
// Comment (1) and uncomment (2) + dotnet run => Drop db
using var scope = builder.Services.BuildServiceProvider().CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<SampleDbContext>();
dbContext.Database.EnsureCreated(); // (1)
// dbContext.Database.EnsureDeleted(); // (2)

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
