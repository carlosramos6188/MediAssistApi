using Microsoft.AspNetCore.Mvc;
using MediAssistApi.DTOs.IA;
using MediAssistApi.Services.Interfaces;
using MediAssistApi.Data;
using MediAssistApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MediAssistApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IAController : ControllerBase
    {
        private readonly IGroqService _groqService;
        private readonly ApplicationDbContext _context;

        public IAController(
            IGroqService groqService,
            ApplicationDbContext context)
        {
            _groqService = groqService;
            _context = context;
        }

        // POST: api/IA/analizar
        [HttpPost("analizar")]
        public async Task<ActionResult<RespuestaAnalisisDto>> Analizar(
            [FromBody] AnalizarSintomasDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Obtener respuesta de la IA
            var respuesta = await _groqService.AnalizarSintomasAsync(dto.Sintomas);

            // Crear registro para guardar en la base de datos
            var analisis = new AnalisisIA
            {
                PacienteId = dto.PacienteId,
                Sintomas = dto.Sintomas,
                Especialidad = respuesta.Especialidad,
                Prioridad = respuesta.Prioridad,
                Analisis = respuesta.Analisis,
                Recomendaciones = respuesta.Recomendaciones,
                FechaAnalisis = DateTime.Now
            };

            // Guardar en SQLite
            _context.AnalisisIA.Add(analisis);
            await _context.SaveChangesAsync();


            Console.WriteLine("=================================");
            Console.WriteLine("ANÁLISIS GUARDADO");
            Console.WriteLine($"ID: {analisis.Id}");
            Console.WriteLine($"Paciente: {analisis.PacienteId}");
            Console.WriteLine("=================================");

            // Devolver la respuesta al cliente
            return Ok(respuesta);
        }

        // GET: api/IA/historial
        [HttpGet("historial")]
        public async Task<ActionResult> Historial()
        {
            var historial = await _context.AnalisisIA
                .OrderByDescending(a => a.FechaAnalisis)
                .ToListAsync();

            return Ok(historial);
        }
    }
}