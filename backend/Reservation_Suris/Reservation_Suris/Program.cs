using Reservation_Suris.Application;
using Reservation_Suris.Domain.Models;
using Reservation_Suris.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Registrar capa de Infra mediante método estático (EF Core InMemory).
builder.Services.AddPersistence();
// Registrar capa de App mediante método estático.
builder.Services.AddApplication();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        policy => policy.WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

# region middlewares
app.UseCors("AllowLocalhost");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
# endregion

# region seed data
// Seed de datos iniciales
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Services.Any())
    {
        context.Services.AddRange(new List<Service>
        {
            new Service { Name = "Corte de cabello", Description = "Servicio profesional de corte", Price = 10.99m, Duration = TimeSpan.FromMinutes(30), IsActive = true },
            new Service { Name = "Masaje", Description = "Masaje relajante de cuerpo completo", Price = 29.99m, Duration = TimeSpan.FromMinutes(60), IsActive = true }
        });
        context.SaveChanges();
    }

    if (!context.Clients.Any())
    {
        context.Clients.AddRange(new List<Client>
        {
            new Client { FirstName = "Juan", LastName = "Pérez", Email = "juan@example.com", PhoneNumber = "123456789" },
            new Client { FirstName = "Ana", LastName = "García", Email = "ana@example.com", PhoneNumber = "987654321" }
        });
        context.SaveChanges();
    }
}
#endregion

app.Run();
