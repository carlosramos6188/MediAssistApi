using System.ComponentModel.DataAnnotations;

namespace MediAssistApi.Models
{
    // Esta clase representa la tabla "Pacientes" en la base de datos.
    public class Paciente
    {
        // [Key] indica que este campo será la clave primaria (Primary Key).
        // Entity Framework lo utilizará para identificar cada registro.
        [Key]
        public int Id { get; set; }

        // [Required] indica que el campo es obligatorio.
        // [MaxLength(100)] limita el texto a un máximo de 100 caracteres.
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Apellido del paciente.
        // También es obligatorio y con un máximo de 100 caracteres.
        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        // Número de documento del paciente.
        // Será obligatorio y tendrá un máximo de 20 caracteres.
        [Required]
        [MaxLength(20)]
        public string Documento { get; set; } = string.Empty;

        // Número telefónico.
        // El signo ? significa que este campo es opcional.
        // [Phone] valida que tenga un formato de teléfono válido.
        [Phone]
        public string? Telefono { get; set; }

        // Correo electrónico del paciente.
        // También es opcional.
        // [EmailAddress] valida que el formato sea correcto.
        [EmailAddress]
        public string? Email { get; set; }

        // Fecha de nacimiento del paciente.
        // Se utilizará para calcular la edad o validar información.
        public DateTime FechaNacimiento { get; set; }
    }
}