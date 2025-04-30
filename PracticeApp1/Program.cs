using Microsoft.EntityFrameworkCore;
using Practice1.Services.EntityFramework.Entities;

var builder = WebApplication.CreateBuilder(args);

var sqliteDatabaseFile = builder.Configuration.GetValue<string?>("SQLiteDatabaseFile", null) ?? throw new Exception("The `SQLiteDatabaseFile` configuration setting is not set.");
var connectionString = builder.Configuration.GetConnectionString("NorthwindDatabase") ?? throw new Exception("The `NorthwindDatabase` connection string is not set.");

if (File.Exists(sqliteDatabaseFile))
{
    File.Delete(sqliteDatabaseFile);
}

// Add services to the container.
using var databaseService = new DatabaseService(connectionString!);
databaseService.InitializeDatabase();

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
