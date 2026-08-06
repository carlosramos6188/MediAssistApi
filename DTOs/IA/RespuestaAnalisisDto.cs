namespace MediAssistApi.DTOs.IA
{
    public class RespuestaAnalisisDto
    {
        // Especialidad médica recomendada por la IA.
        public string Especialidad { get; set; } = string.Empty;

        // Nivel de prioridad del caso.
        public string Prioridad { get; set; } = string.Empty;

        // Explicación generada por la IA.
        public string Analisis { get; set; } = string.Empty;

        // Recomendaciones para el paciente.
        public string Recomendaciones { get; set; } = string.Empty;
    }
}