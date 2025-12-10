using Microsoft.EntityFrameworkCore;
using ssi730ebu202319415.API.Inventory.Application.Internal.CommandServices;
using ssi730ebu202319415.API.Inventory.Domain.Repositories;
using ssi730ebu202319415.API.Inventory.Infrastructure.Persistence.EFC.Repositories;
using ssi730ebu202319415.API.Observability.Application.Internal.CommandServices;
using ssi730ebu202319415.API.Observability.Domain.Repositories;
using ssi730ebu202319415.API.Observability.Domain.Services;
using ssi730ebu202319415.API.Observability.Infrastructure.ACL;
using ssi730ebu202319415.API.Observability.Infrastructure.Persistence.EFC.Repositories;
using ssi730ebu202319415.API.Shared.Domain.Repositories;
using ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ssi730ebu202319415.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONEXIÓN A MYSQL CORRECTA (¡SIN MIGRANTES!)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? "Server=localhost;Database=irriot;Uid=root;Pwd=;";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IThingRepository, ThingRepository>();
builder.Services.AddScoped<IThingCommandService, ThingCommandService>();
builder.Services.AddScoped<IThingStateRepository, ThingStateRepository>();
builder.Services.AddScoped<IThingStateCommandService, ThingStateCommandService>();
builder.Services.AddScoped<IInventoryAcl, InventoryAcl>();

var app = builder.Build();

// ESTO ES LO QUE FALTABA: CREAR LA BD SIN MORIRSE SI FALLA
using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated(); // Crea la base de datos si no existe
        Console.WriteLine("Base de datos 'irriot' creada correctamente");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al crear la BD: {ex.Message}");
        Console.WriteLine("Revisa que MySQL esté encendido y la contraseña sea correcta");
    }
}

// Swagger + HTTPS
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyIRRIOT API V1");
        c.RoutePrefix = string.Empty; // <-- PARA QUE ABRA SWAGGER AL INICIAR
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();