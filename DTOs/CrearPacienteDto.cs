// Importa las anotaciones de validación.
// Nos permite utilizar atributos como [Required], [EmailAddress], etc.
using System.ComponentModel.DataAnnotations;

namespace MediAssistApi.DTOs
{
    // Este DTO se utiliza cuando el usuario crea un nuevo paciente.
    // Solo contiene la información que debe enviar el cliente.
    public class CrearPacienteDto
    {
        // El nombre es obligatorio.
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        // El apellido es obligatorio.
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres.")]
        public string Apellido { get; set; } = string.Empty;

        // El documento es obligatorio.
        [Required(ErrorMessage = "El documento es obligatorio.")]
        [StringLength(20, ErrorMessage = "El documento no puede superar los 20 caracteres.")]
        public string Documento { get; set; } = string.Empty;

        // El teléfono es opcional.
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string? Telefono { get; set; }

        // El correo es opcional, pero si se envía debe ser válido.
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string? Email { get; set; }

        // La fecha de nacimiento es obligatoria.
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }
    }
}