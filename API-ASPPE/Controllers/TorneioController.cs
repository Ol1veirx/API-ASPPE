using API_ASPPE.Models;
using API_ASPPE.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_ASPPE.Controllers
{
    [ApiController]
    [Route("Torneio")]
    public class TorneioController : Controller
    {
        private readonly TorneioServices _services;
        public TorneioController(TorneioServices services) 
        {
            _services = services;
        }

        [HttpGet]
        public async Task<List<Torneio>> GetAll()
        {
            return await _services.ListarTorneios();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Torneio>> GetById(int? id)
        {
            if (id == null) return NotFound();
            var torneio = await _services.DetalheTorneio(id.Value);
            if(torneio == null) return NotFound();
            return Ok(torneio);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Torneio torneio)
        {
            await _services.CriarTorneio(torneio);
            return CreatedAtAction(nameof(GetById), new Torneio { Id = torneio.Id }, torneio);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Torneio torneio)
        {
            if(id != torneio.Id) return NotFound();
            await _services.AlterarTorneio(torneio);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var torneio = await _services.DetalheTorneio(id);
            
            if(torneio == null) return NotFound();
            _services.ExcluirTorneio(id);
            return NoContent();
        }
    }
}
