using NaLibApi.Data;
using NaLibApi.Models;
using NaLibApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add postgresql connection string to the configuration
var configuration = builder.Configuration;
builder.Services.AddDbContext<NaLibDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
});

// Add mongodb connection string to the configuration
builder.Services.Configure<NoSQLDbContext>(configuration.GetSection("NoSQLConnection"));

// Add services to the container.  
builder.Services.AddSingleton<CatalogService>();

// Add services to the container.
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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
