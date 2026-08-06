using System.ComponentModel.DataAnnotations;

namespace MediAssistApi.Models
{
    // Representa las especialidades médicas disponibles.
    // Ejemplo: Cardiología, Pediatría, Dermatología.
    public class Especialidad
    {
        // Clave primaria de la tabla.
        [Key]
        public int Id { get; set; }

        // Nombre de la especialidad.
        // Es obligatorio y no puede superar los 100 caracteres.
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Breve descripción de la especialidad.
        // Es opcional y tiene un límite de 250 caracteres.
        [MaxLength(250)]
        public string? Descripcion { get; set; }
    }
}