using Microsoft.EntityFrameworkCore;
using Practice1.Services.EntityFramework.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PracticeContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Data Source=app.db")));

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
