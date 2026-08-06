using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediAssistApi.Data;
using MediAssistApi.DTOs;
using MediAssistApi.Models;

namespace MediAssistApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ============================================
        // GET: api/Especialidades
        // Obtiene todas las especialidades.
        // ============================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EspecialidadDto>>> ObtenerEspecialidades()
        {
            var especialidades = await _context.Especialidades.ToListAsync();

            var resultado = especialidades.Select(e => new EspecialidadDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion
            });

            return Ok(resultado);
        }

        // ============================================
        // GET: api/Especialidades/{id}
        // Obtiene una especialidad por Id.
        // ============================================
        [HttpGet("{id}")]
        public async Task<ActionResult<EspecialidadDto>> ObtenerEspecialidad(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
                return NotFound("Especialidad no encontrada.");

            return Ok(new EspecialidadDto
            {
                Id = especialidad.Id,
                Nombre = especialidad.Nombre,
                Descripcion = especialidad.Descripcion
            });
        }

        // ============================================
        // POST: api/Especialidades
        // Crea una nueva especialidad.
        // ============================================
        [HttpPost]
        public async Task<ActionResult> CrearEspecialidad(CrearEspecialidadDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var especialidad = new Especialidad
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };

            await _context.Especialidades.AddAsync(especialidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerEspecialidad),
                new { id = especialidad.Id },
                especialidad);
        }

        // ============================================
        // PUT: api/Especialidades/{id}
        // Actualiza una especialidad.
        // ============================================
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarEspecialidad(int id, ActualizarEspecialidadDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
                return NotFound("Especialidad no encontrada.");

            especialidad.Nombre = dto.Nombre;
            especialidad.Descripcion = dto.Descripcion;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Especialidad actualizada correctamente."
            });
        }

        // ============================================
        // DELETE: api/Especialidades/{id}
        // Elimina una especialidad.
        // ============================================
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarEspecialidad(int id)
        {
            var especialidad = await _context.Especialidades.FindAsync(id);

            if (especialidad == null)
                return NotFound("Especialidad no encontrada.");

            _context.Especialidades.Remove(especialidad);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Especialidad eliminada correctamente."
            });
        }
    }
}