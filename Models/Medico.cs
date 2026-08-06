using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediAssistApi.Models
{
    // Representa un médico registrado en el sistema.
    public class Medico
    {
        // Clave primaria.
        [Key]
        public int Id { get; set; }

        // Nombre del médico.
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Apellido del médico.
        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        // Teléfono de contacto.
        public string? Telefono { get; set; }

        // Correo electrónico.
        [EmailAddress]
        public string? Email { get; set; }

        // Llave foránea hacia Especialidad.
        public int EspecialidadId { get; set; }

        // Relación con la tabla Especialidades.
        [ForeignKey(nameof(EspecialidadId))]
        public Especialidad? Especialidad { get; set; }
    }
}