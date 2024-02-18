using API_ASPPE.Data;
using API_ASPPE.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ASPPE.Services
{
    public class EquipeServices
    {
        private readonly APContext _context;
        public EquipeServices(APContext context)
        {
            _context = context;
        }
        public async Task<Equipe> AdicionarEquipe(int torneioId, string nome)
        {
            var torneioExiste = await _context.Torneios.FirstOrDefaultAsync(t => t.Id == torneioId);

            if (torneioExiste == null) return null;

            var novaEquipe = new Equipe
            {
                Nome = nome,
            };

            torneioExiste.Equipes.Add(novaEquipe);
            await _context.SaveChangesAsync();

            return novaEquipe;
        }

        public async Task<bool> RemoverEquipe(int torneioId, int equipeId)
        {
            var torneio = await _context.Torneios.Include(t => t.Equipes).FirstOrDefaultAsync(t => t.Id ==  equipeId);

            if(torneio == null) return false;

            var equipe = await _context.Equipes.FirstOrDefaultAsync(e => e.Id == equipeId);
            
            if(equipe == null) return false;

            torneio.Equipes.Remove(equipe);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
