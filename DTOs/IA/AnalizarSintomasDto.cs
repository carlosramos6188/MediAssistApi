using System.ComponentModel.DataAnnotations;

namespace MediAssistApi.DTOs.IA
{
    public class AnalizarSintomasDto
    {
        [Required]
        public int PacienteId { get; set; }

        [Required]
        public string Sintomas { get; set; } = string.Empty;
    }
}