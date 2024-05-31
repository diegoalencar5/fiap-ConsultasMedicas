using Consultas.ApplicationCore.Entities;
using Consultas.ApplicationCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pacientes.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepository _repository;
        public PacientesController(IPacienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var Pacientes = await _repository.GetAll();

            if (Pacientes == null)
            {
                return BadRequest("Não existem Pacientes");
            }

            return Ok(Pacientes.ToList());
        }

        [HttpGet("{idPaciente}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int idPaciente)
        {
            var Paciente = await _repository.GetById(idPaciente);

            if (Paciente == null)
            {
                return NotFound("Paciente não encontrada pelo id informado");
            }

            return Ok(Paciente);
        }

        [HttpPost]
        public async Task<IActionResult> PostPaciente([FromBody] Paciente Paciente)
        {
            if (Paciente == null)
            {
                return BadRequest("Dados inválidos");
            }

            await _repository.Insert(Paciente);

            return CreatedAtAction(nameof(GetPaciente), new { idPaciente = Paciente.IdPaciente }, Paciente);
        }

        [HttpPut("{idPaciente}")]
        public async Task<IActionResult> PutPaciente(int idPaciente, Paciente Paciente)
        {
            if (idPaciente != Paciente.IdPaciente)
            {
                return BadRequest($"O código da Paciente {idPaciente} não confere");
            }

            try
            {
                await _repository.Update(idPaciente, Paciente);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Atualização da Paciente realizada com sucesso");
        }

        [HttpDelete("{idPaciente}")]
        public async Task<ActionResult<Paciente>> DeletePaciente(int idPaciente)
        {
            var Paciente = await _repository.GetById(idPaciente);
            if (Paciente == null)
            {
                return NotFound($"Paciente com Id {idPaciente} não foi encontrada");
            }

            await _repository.Delete(idPaciente);

            return Ok(Paciente);
        }
    }
}
