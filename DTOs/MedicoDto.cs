namespace MediAssistApi.DTOs
{
    public class MedicoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public int EspecialidadId { get; set; }
    }
}