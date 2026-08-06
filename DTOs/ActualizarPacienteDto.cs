// Importa las anotaciones de validación.
using System.ComponentModel.DataAnnotations;

namespace MediAssistApi.DTOs
{
    // Este DTO se utiliza para actualizar un paciente existente.
    // Contiene únicamente los datos que pueden modificarse.
    public class ActualizarPacienteDto
    {
        // Nombre del paciente (obligatorio).
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        // Apellido del paciente (obligatorio).
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres.")]
        public string Apellido { get; set; } = string.Empty;

        // Documento del paciente (obligatorio).
        [Required(ErrorMessage = "El documento es obligatorio.")]
        [StringLength(20, ErrorMessage = "El documento no puede superar los 20 caracteres.")]
        public string Documento { get; set; } = string.Empty;

        // Teléfono (opcional).
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string? Telefono { get; set; }

        // Correo electrónico (opcional).
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string? Email { get; set; }

        // Fecha de nacimiento (obligatoria).
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }
    }
}