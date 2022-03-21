using diretoaoponto.Persistence;
using diretoaoponto.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DevJobsCs");

builder.Services.AddDbContext<DevJobsContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IJobVacancyRepository, JobVacancyRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(a =>
{
    a.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "diretoaoponto",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Anderson",
            Email = "Andersondev@gmail.com",
            Url = new Uri("https://github.com/AndersonQS")
        }
    });

    var xmlFile = $"diretoaoponto.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    a.IncludeXmlComments(xmlPath);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
