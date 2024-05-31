using Consultas.ApplicationCore.Entities;
using Consultas.ApplicationCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medicos.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoRepository _repository;
        public MedicosController(IMedicoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            var Medicos = await _repository.GetAll();

            if (Medicos == null)
            {
                return BadRequest("Não existem Medicos");
            }

            return Ok(Medicos.ToList());
        }

        [HttpGet("{idMedico}")]
        public async Task<ActionResult<Medico>> GetMedico(int idMedico)
        {
            var Medico = await _repository.GetById(idMedico);

            if (Medico == null)
            {
                return NotFound("Medico não encontrada pelo id informado");
            }

            return Ok(Medico);
        }

        [HttpPost]
        public async Task<IActionResult> PostMedico([FromBody] Medico Medico)
        {
            if (Medico == null)
            {
                return BadRequest("Dados inválidos");
            }

            await _repository.Insert(Medico);

            return CreatedAtAction(nameof(GetMedico), new { idMedico = Medico.IdMedico }, Medico);
        }

        [HttpPut("{idMedico}")]
        public async Task<IActionResult> PutMedico(int idMedico, Medico Medico)
        {
            if (idMedico != Medico.IdMedico)
            {
                return BadRequest($"O código da Medico {idMedico} não confere");
            }

            try
            {
                await _repository.Update(idMedico, Medico);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Atualização da Medico realizada com sucesso");
        }

        [HttpDelete("{idMedico}")]
        public async Task<ActionResult<Medico>> DeleteMedico(int idMedico)
        {
            var Medico = await _repository.GetById(idMedico);
            if (Medico == null)
            {
                return NotFound($"Medico com Id {idMedico} não foi encontrada");
            }

            await _repository.Delete(idMedico);

            return Ok(Medico);
        }
    }
}
