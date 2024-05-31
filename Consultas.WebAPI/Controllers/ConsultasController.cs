using Consultas.ApplicationCore.Entities;
using Consultas.ApplicationCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consultas.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class ConsultasController : ControllerBase
    {
        private readonly IConsultaRepository _repository;
        public ConsultasController(IConsultaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Consulta>>> GetConsultas()
        {
            var Consultas = await _repository.GetAll();

            if (Consultas == null)
            {
                return BadRequest("N�o existem Consultas");
            }

            return Ok(Consultas.ToList());
        }

        [HttpGet("{idConsulta}")]
        public async Task<ActionResult<Consulta>> GetConsulta(int idConsulta)
        {
            var Consulta = await _repository.GetById(idConsulta);

            if (Consulta == null)
            {
                return NotFound("Consulta n�o encontrada pelo id informado");
            }

            return Ok(Consulta);
        }

        [HttpPost]
        public async Task<IActionResult> PostConsulta([FromBody] Consulta Consulta)
        {
            if (Consulta == null)
            {
                return BadRequest("Dados inv�lidos");
            }

            await _repository.Insert(Consulta);

            return CreatedAtAction(nameof(GetConsulta), new { idConsulta = Consulta.IdConsulta }, Consulta);
        }

        [HttpPut("{idConsulta}")]
        public async Task<IActionResult> PutConsulta(int idConsulta, Consulta Consulta)
        {
            if (idConsulta != Consulta.IdConsulta)
            {
                return BadRequest($"O c�digo da Consulta {idConsulta} n�o confere");
            }

            try
            {
                await _repository.Update(idConsulta, Consulta);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Atualiza��o da Consulta realizada com sucesso");
        }

        [HttpDelete("{idConsulta}")]
        public async Task<ActionResult<Consulta>> DeleteConsulta(int idConsulta)
        {
            var Consulta = await _repository.GetById(idConsulta);
            if (Consulta == null)
            {
                return NotFound($"Consulta com Id {idConsulta} n�o foi encontrada");
            }

            await _repository.Delete(idConsulta);

            return Ok(Consulta);
        }
    }
}
