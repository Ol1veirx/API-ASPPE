using API_ASPPE.Models;
using API_ASPPE.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_ASPPE.Controllers
{
    [ApiController]
    [Route("etapa")]
    public class EtapaController : Controller
    {
        private readonly EtapaServices _services;
        public EtapaController(EtapaServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Etapa>> ObterEtapaId(int etapaId)
        {
            try
            {
                return await _services.ObterEtapaId(etapaId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex}");
            }
            
           
        }

        [HttpPost]
        public async Task<ActionResult<Etapa>> Create(Etapa etapa)
        {
            var novaEtapa = await _services.CriarEtapa(etapa);
            return CreatedAtAction(nameof(ObterEtapaId), new {id =  novaEtapa.Id}, novaEtapa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarEtapa(int id, Etapa etapa)
        {
            if (id != etapa.Id) return BadRequest();

            var result = await _services.AtualizarEtapa(id, etapa);
            if(!result) return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoverEtapa(int id)
        {
            var index = await _services.RemoverEtapa(id);
            if (!index) return BadRequest();
            return NoContent();
        }

        [HttpPost("{etapaId}/equipe/{equipeId}")]
        public async Task<ActionResult> AdicionarEquipeNaEtapa(int etapaId, int equipeId)
        {
            var novaEquipe = await _services.AdicionarEquipeDaEtapa(etapaId, equipeId);
            if(!novaEquipe) return BadRequest();
            return NoContent();
        }
        [HttpDelete("{etapaId}/equipe/{equipeId}")]
        public async Task<ActionResult> RemoverEquipeDaEtapa(int etapaId, int equipeId)
        {
            var removerEquipe = await _services.RemoverEquipeDaEtapa(etapaId, equipeId);
            if (!removerEquipe) return BadRequest();
            return NoContent();
        }

    }
}
