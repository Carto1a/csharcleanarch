using CSharpCleanArch.Infrastructure.Database.EntityFramework;
using CSharpCleanArch.Application;
using CSharpCleanArch.Infrastructure.Filter;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
configuration.AddJsonFile("appsettings.Local.json");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionFilter();

builder.Services.AddEntityFramework(configuration);
builder.Services.AddApplication();

var app = builder.Build();

app.MigrateDatabase();

// Configure the HTTP request pipeline.
/* if (app.Environment.IsDevelopment()) */
/* { */
    app.UseSwagger();
    app.UseSwaggerUI();
/* } */

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();