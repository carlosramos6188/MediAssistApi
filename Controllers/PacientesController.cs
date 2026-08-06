using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediAssistApi.Data;
using MediAssistApi.Models;
using MediAssistApi.DTOs;

namespace MediAssistApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PacientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =====================================================
        // GET: api/Pacientes
        // Obtiene todos los pacientes.
        // =====================================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDto>>> ObtenerPacientes()
        {
            var pacientes = await _context.Pacientes.ToListAsync();

            var resultado = pacientes.Select(p => new PacienteDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Documento = p.Documento,
                Telefono = p.Telefono,
                Email = p.Email,
                FechaNacimiento = p.FechaNacimiento
            }).ToList();

            return Ok(resultado);
        }

        // =====================================================
        // GET: api/Pacientes/{id}
        // Obtiene un paciente por Id.
        // =====================================================
        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDto>> ObtenerPaciente(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
                return NotFound("Paciente no encontrado.");

            var resultado = new PacienteDto
            {
                Id = paciente.Id,
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Documento = paciente.Documento,
                Telefono = paciente.Telefono,
                Email = paciente.Email,
                FechaNacimiento = paciente.FechaNacimiento
            };

            return Ok(resultado);
        }

        // =====================================================
        // POST: api/Pacientes
        // Crea un nuevo paciente.
        // =====================================================
        [HttpPost]
        public async Task<ActionResult> CrearPaciente(CrearPacienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paciente = new Paciente
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Documento = dto.Documento,
                Telefono = dto.Telefono,
                Email = dto.Email,
                FechaNacimiento = dto.FechaNacimiento
            };

            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(ObtenerPaciente),
                new { id = paciente.Id },
                paciente);
        }

        // =====================================================
        // PUT: api/Pacientes/{id}
        // Actualiza un paciente existente.
        // =====================================================
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarPaciente(int id, ActualizarPacienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Buscar el paciente en la base de datos.
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
                return NotFound("Paciente no encontrado.");

            // Actualizar los datos.
            paciente.Nombre = dto.Nombre;
            paciente.Apellido = dto.Apellido;
            paciente.Documento = dto.Documento;
            paciente.Telefono = dto.Telefono;
            paciente.Email = dto.Email;
            paciente.FechaNacimiento = dto.FechaNacimiento;

            // Guardar cambios.
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Paciente actualizado correctamente."
            });
        }

        // =====================================================
        // DELETE: api/Pacientes/{id}
        // Elimina un paciente.
        // =====================================================
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarPaciente(int id)
        {
            // Buscar el paciente.
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
                return NotFound("Paciente no encontrado.");

            // Eliminar el paciente.
            _context.Pacientes.Remove(paciente);

            // Guardar cambios.
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Paciente eliminado correctamente."
            });
        }
    }
}