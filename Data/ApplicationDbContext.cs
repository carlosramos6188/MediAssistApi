// Importa Entity Framework Core.
// Contiene la clase DbContext y todas las herramientas para trabajar con la base de datos.
using Microsoft.EntityFrameworkCore;

// Importa nuestros modelos.
using MediAssistApi.Models;

namespace MediAssistApi.Data
{
    // ApplicationDbContext hereda de DbContext.
    // Será el puente entre la aplicación y la base de datos.
    public class ApplicationDbContext : DbContext
    {
        // Constructor.
        // Recibe la configuración de la conexión a la base de datos.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Cada DbSet representa una tabla en la base de datos.

        // Tabla Pacientes
        public DbSet<Paciente> Pacientes { get; set; }

        // Tabla Médicos
        public DbSet<Medico> Medicos { get; set; }

        // Tabla Especialidades
        public DbSet<Especialidad> Especialidades { get; set; }

        // Tabla de análisis realizados por la IA.
        public DbSet<AnalisisIA> AnalisisIA { get; set; }
    }

}