using AspNetCore.Authentication.ApiKey;
using Microsoft.EntityFrameworkCore;
using Sorteo.API.Middleware;
using Sorteo.Application.Services;
using Sorteo.Domain.Interfaces;
using Sorteo.Infrastructure;
using Sorteo.Infrastructure.Data;
using Sorteo.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configurar la conexion de base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar ApplicationDbContext en el contenedor de inyeccion de dependencias
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registrar servicios de aplicacion y de infraestructura

builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<AsignacionService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IAsignacionRepository, AsignacionRepository>();

// Configurar autenticación
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "ApiKey";
    options.DefaultChallengeScheme = "ApiKey";
}).AddApiKeyInHeader("ApiKey", options =>
{
    options.Realm = "Authorization";
    options.KeyName = "Api-Key";
});

// Agregar autorización
builder.Services.AddAuthorization();


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
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>("jPQ4tqcTNf8XwwCfLUrFn7CrmxGcanFWvXZG0JoU6Kn31GjZAjwnCc0Qzf0AqLMz");


app.MapControllers();

app.Run();
