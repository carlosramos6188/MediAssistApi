using MediAssistApi.Data;
using Microsoft.EntityFrameworkCore;
using MediAssistApi.Services;
using MediAssistApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Entity Framework Core con SQLite.
// Obtiene la cadena de conexión desde appsettings.json.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega soporte para controladores.
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Permite realizar peticiones HTTP a servicios externos como Groq.
builder.Services.AddHttpClient();
builder.Services.AddScoped<IGroqService, GroqService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();


// Mapea los controladores.
app.MapControllers();


app.Run();
