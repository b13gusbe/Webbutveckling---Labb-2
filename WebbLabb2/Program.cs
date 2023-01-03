using Microsoft.EntityFrameworkCore;
using WebbLabb2.DAL;
using WebbLabb2.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<BokhandelContext>(options =>
{
    var connectionString = "Server=.\\;Database=Bokhandel;Trusted_Connection=True;Encrypt=False;";
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.MapControllers();

app.Run();
