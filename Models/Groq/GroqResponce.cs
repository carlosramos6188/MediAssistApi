using System.Text.Json.Serialization;

namespace MediAssistApi.Models.Groq
{
    public class GroqResponse
    {
        [JsonPropertyName("choices")]
        public List<Choice> Choices { get; set; } = new();
    }

    public class Choice
    {
        [JsonPropertyName("message")]
        public Message Message { get; set; } = new();
    }

    public class Message
    {
        [JsonPropertyName("content")]
        public string Content { get; set; } = string.Empty;
    }
}