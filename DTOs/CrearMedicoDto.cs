using System.ComponentModel.DataAnnotations;

namespace MediAssistApi.DTOs
{
    public class CrearMedicoDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        public string? Telefono { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public int EspecialidadId { get; set; }
    }
}