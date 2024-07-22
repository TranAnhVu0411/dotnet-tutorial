using System.Text.Json.Serialization;
using EfCoreRelationshipDemo.Data;
using EfCoreRelationshipDemo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<InvoiceDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Seperating the DB Configuration
builder.Services.AddDbContext<SampleDbContext>();

builder.Services.AddControllers()
// Tránh trường hợp vòng lặp đệ quy
// Ví dụ:
// {
//     id: "p1",
//     children: [
//         {
//             id: "c1",
//             parent: {
//                 id: "c1",
//                 children: [
//                     ...
//                 ]
//             } 
//         }
//     ]
// }
.AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });

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
