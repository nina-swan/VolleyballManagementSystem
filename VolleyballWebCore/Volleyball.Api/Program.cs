using Microsoft.EntityFrameworkCore;
using Volleyball.Infrastructure.Database.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<VolleyballContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VolleyballDatabaseWebio"));
});


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
