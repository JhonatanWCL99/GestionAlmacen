using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PruebaTecnicaSitec.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoSwaggerAnnotation", Version="v1" });
        c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "DemoSwaggerAnnotation.xml"));
    });
builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<AlmacenDB>(options => options.UseNpgsql(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

