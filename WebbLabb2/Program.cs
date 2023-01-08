using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebbLabb2.DAL;
using WebbLabb2.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
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
