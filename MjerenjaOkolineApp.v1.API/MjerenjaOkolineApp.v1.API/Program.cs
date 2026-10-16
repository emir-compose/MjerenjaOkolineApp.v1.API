using Microsoft.EntityFrameworkCore;
using MjerenjaOkolineApp.v1.API.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(
        "Server=localhost,1433;" +
        "Database=MyMjerenjeApp.v1;" +
        "Trusted_Connection=False;" +
        "User ID=sa;" +
        "Password=proba123;" +
        "MultipleActiveResultSets=True;" +
        "TrustServerCertificate=True;"
        ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
