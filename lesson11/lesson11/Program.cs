using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
DBActions actions = new DBActions(builder.Configuration);
var connString = actions.GetConnectionString("AcademyDB");
builder.Services.AddDbContext<AcademyContext>(opt => opt.UseSqlServer(connString));
builder.Services.AddScoped<IUniversityRepo, UniversityRepo>();
builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<IUniversityRankingRepo, UniversityRankingRepo>();
var app = builder.Build();
app.MapControllers();
app.Run();
