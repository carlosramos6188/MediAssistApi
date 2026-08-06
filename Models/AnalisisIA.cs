using System.ComponentModel.DataAnnotations;

namespace MediAssistApi.Models
{
    // Guarda cada análisis realizado por la IA.
    public class AnalisisIA
    {
        // Clave primaria.
        [Key]
        public int Id { get; set; }

        // Paciente al que pertenece el análisis.
        public int PacienteId { get; set; }

        // Síntomas escritos por el paciente.
        [Required]
        public string Sintomas { get; set; } = string.Empty;

        // Especialidad recomendada por la IA.
        public string Especialidad { get; set; } = string.Empty;

        // Nivel de prioridad.
        public string Prioridad { get; set; } = string.Empty;

        // Explicación generada por la IA.
        public string Analisis { get; set; } = string.Empty;

        // Recomendaciones generadas por la IA.
        public string Recomendaciones { get; set; } = string.Empty;

        // Fecha del análisis.
        public DateTime FechaAnalisis { get; set; } = DateTime.Now;
    }
}