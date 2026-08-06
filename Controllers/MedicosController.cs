using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediAssistApi.Data;
using MediAssistApi.Models;
using MediAssistApi.DTOs;

namespace MediAssistApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MedicosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ============================================
        // GET: api/Medicos
        // Obtiene todos los médicos.
        // ============================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoDto>>> ObtenerMedicos()
        {
            var medicos = await _context.Medicos.ToListAsync();

            var resultado = medicos.Select(m => new MedicoDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Apellido = m.Apellido,
                Telefono = m.Telefono,
                Email = m.Email,
                EspecialidadId = m.EspecialidadId
            });

            return Ok(resultado);
        }

        // ============================================
        // GET: api/Medicos/{id}
        // Obtiene un médico por Id.
        // ============================================
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicoDto>> ObtenerMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
                return NotFound("Médico no encontrado.");

            var resultado = new MedicoDto
            {
                Id = medico.Id,
                Nombre = medico.Nombre,
                Apellido = medico.Apellido,
                Telefono = medico.Telefono,
                Email = medico.Email,
                EspecialidadId = medico.EspecialidadId
            };

            return Ok(resultado);
        }

        // ============================================
        // POST: api/Medicos
        // Crea un nuevo médico.
        // ============================================
        [HttpPost]
        public async Task<ActionResult> CrearMedico(CrearMedicoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var especialidad = await _context.Especialidades.FindAsync(dto.EspecialidadId);

            if (especialidad == null)
                return BadRequest("La especialidad indicada no existe.");

            var medico = new Medico
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Telefono = dto.Telefono,
                Email = dto.Email,
                EspecialidadId = dto.EspecialidadId
            };

            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerMedico), new { id = medico.Id }, medico);
        }

        // ============================================
        // PUT: api/Medicos/{id}
        // Actualiza un médico.
        // ============================================
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarMedico(int id, ActualizarMedicoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
                return NotFound("Médico no encontrado.");

            medico.Nombre = dto.Nombre;
            medico.Apellido = dto.Apellido;
            medico.Telefono = dto.Telefono;
            medico.Email = dto.Email;
            medico.EspecialidadId = dto.EspecialidadId;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Médico actualizado correctamente."
            });
        }

        // ============================================
        // DELETE: api/Medicos/{id}
        // Elimina un médico.
        // ============================================
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarMedico(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);

            if (medico == null)
                return NotFound("Médico no encontrado.");

            _context.Medicos.Remove(medico);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Médico eliminado correctamente."
            });
        }
    }
}