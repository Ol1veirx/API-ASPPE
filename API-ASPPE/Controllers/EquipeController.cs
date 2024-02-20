using API_ASPPE.Models;
using API_ASPPE.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_ASPPE.Controllers
{
    [ApiController]
    [Route("equipe")]
    public class EquipeController : Controller
    {
        private readonly EquipeServices _service;
        public EquipeController(EquipeServices service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipe>> GetEquipe(int id)
        {
            try
            {
                var equipe = await _service.GetEquipe(id);
                if (equipe == null) return NotFound();
                return equipe;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no servidor: {ex}");
            }
        }

        [HttpPost("{torneioId}")]

        public async Task<ActionResult<Equipe>> AddEquipe(int torneioId, [FromBody] Equipe equipe)
        {
            try
            {
                var novaEquipe = await _service.AdicionarEquipe(torneioId, equipe);
                if (novaEquipe == null) return NotFound("Torneio não encontrado");
                return CreatedAtAction(nameof(GetEquipe), new { id = novaEquipe.Id }, novaEquipe);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no Servidor: {ex}");
            }
        }
        [HttpDelete("{torneioId}/{equipeId}")]
        public async Task<ActionResult> Delete(int torneioId, int equipeId)
        {
            try
            {
                var equipeRemovida = await _service.RemoverEquipe(torneioId, equipeId);
                if (!equipeRemovida) return BadRequest();
                return Ok(equipeRemovida);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro no Servidor: {ex}");
            }
        }
        [HttpPut("{torneioId}/{equipeId}")]
        public async Task<ActionResult> AlterarEquipe(int torneioId, int equipeId, Equipe equipe)
        {
            try
            {
                var alterarEquipe = await _service.AlterarEquipe(torneioId, equipeId, equipe);
                if (alterarEquipe == null) return BadRequest();
                return Ok(alterarEquipe);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro no Servidor: {e}");
            }
        }
        
    }
}
