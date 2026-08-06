using System.Text.Json.Serialization;

namespace MediAssistApi.DTOs.IA
{
    public class RespuestaGroqDto
    {
        [JsonPropertyName("especialidad")]
        public string Especialidad { get; set; } = string.Empty;

        [JsonPropertyName("prioridad")]
        public string Prioridad { get; set; } = string.Empty;

        [JsonPropertyName("analisis")]
        public string Analisis { get; set; } = string.Empty;

        [JsonPropertyName("recomendaciones")]
        public string Recomendaciones { get; set; } = string.Empty;
    }
}