using System.ComponentModel.DataAnnotations;

namespace MediAssistApi.DTOs
{
    public class ActualizarEspecialidadDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Descripcion { get; set; }
    }
}