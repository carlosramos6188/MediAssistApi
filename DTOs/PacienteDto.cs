// Define el espacio de nombres (namespace) donde estará este archivo.
// Esto ayuda a organizar el proyecto.
namespace MediAssistApi.DTOs
{
    // Este DTO representa la información que la API devolverá
    // cuando se consulte un paciente.
    public class PacienteDto
    {
        // Identificador único del paciente.
        public int Id { get; set; }

        // Nombre del paciente.
        public string Nombre { get; set; } = string.Empty;

        // Apellido del paciente.
        public string Apellido { get; set; } = string.Empty;

        // Número de documento.
        public string Documento { get; set; } = string.Empty;

        // Número telefónico.
        // Puede ser nulo porque no todos los pacientes lo registran.
        public string? Telefono { get; set; }

        // Correo electrónico.
        // También puede ser nulo.
        public string? Email { get; set; }

        // Fecha de nacimiento.
        public DateTime FechaNacimiento { get; set; }
    }
}