using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MediAssistApi.DTOs.IA;
using MediAssistApi.Models.Groq;
using MediAssistApi.Services.Interfaces;

namespace MediAssistApi.Services
{
    // Servicio encargado de comunicarse con la API de Groq.
    public class GroqService : IGroqService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GroqService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<RespuestaAnalisisDto> AnalizarSintomasAsync(string sintomas)
        {
            // Obtiene la API Key y el modelo desde appsettings.json
            var apiKey = _configuration["Groq:ApiKey"];
            var modelo = _configuration["Groq:Model"];

            // Configura la autenticación
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            // Crea el prompt para la IA
            var prompt =
                "Eres un asistente médico.\n\n" +
                "Analiza los siguientes síntomas:\n\n" +
                sintomas +
                "\n\n" +
                "Responde ÚNICAMENTE en formato JSON válido, sin explicaciones adicionales.\n\n" +
                "{\n" +
                "  \"especialidad\": \"\",\n" +
                "  \"prioridad\": \"\",\n" +
                "  \"analisis\": \"\",\n" +
                "  \"recomendaciones\": \"\"\n" +
                "}";

            // Objeto que se enviará a Groq
            var request = new
            {
                model = modelo,
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = prompt
                    }
                },
                temperature = 0.3
            };

            // Convierte el objeto a JSON
            var json = JsonSerializer.Serialize(request);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            // Envía la petición a Groq
            var response = await _httpClient.PostAsync(
                "https://api.groq.com/openai/v1/chat/completions",
                content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error de Groq: {error}");
            }

            // Lee la respuesta
            var responseJson = await response.Content.ReadAsStringAsync();

            // Convierte el JSON de Groq a un objeto
            var groqResponse = JsonSerializer.Deserialize<GroqResponse>(responseJson);

            // Obtiene únicamente el contenido generado por la IA
            var contenido = groqResponse?
                .Choices
                .FirstOrDefault()?
                .Message
                .Content;

            if (string.IsNullOrWhiteSpace(contenido))
            {
                throw new Exception("Groq no devolvió contenido.");
            }

            // Intenta convertir la respuesta de la IA a un objeto
            try
            {
                var respuestaIA = JsonSerializer.Deserialize<RespuestaGroqDto>(
                    contenido,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                if (respuestaIA != null)
                {
                    return new RespuestaAnalisisDto
                    {
                        Especialidad = respuestaIA.Especialidad,
                        Prioridad = respuestaIA.Prioridad,
                        Analisis = respuestaIA.Analisis,
                        Recomendaciones = respuestaIA.Recomendaciones
                    };
                }
            }
            catch
            {
                // Si la IA no respondió en formato JSON,
                // devolveremos el texto completo.
            }

            // Respuesta de respaldo
            return new RespuestaAnalisisDto
            {
                Especialidad = "No identificada",
                Prioridad = "No identificada",
                Analisis = contenido,
                Recomendaciones = "No disponibles"
            };
        }
    }
}