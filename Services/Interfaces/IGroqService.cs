using MediAssistApi.DTOs.IA;

namespace MediAssistApi.Services.Interfaces
{
    public interface IGroqService
    {
        Task<RespuestaAnalisisDto> AnalizarSintomasAsync(string sintomas);
    }
}