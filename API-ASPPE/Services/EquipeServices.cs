using API_ASPPE.Data;
using API_ASPPE.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Equipe> GetEquipe(int id)
        {
            return await _context.Equipes.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Equipe> AdicionarEquipe(int torneioId, Equipe equipe)
        {
            
                var torneio = await _context.Torneios.FindAsync(torneioId);
                if (torneio == null) return null;

                /*var novaEquipe = new Equipe
                {
                    Nome = nomeEquipe
                };*/

                equipe.TorneioId = torneioId;
                _context.Equipes.Add(equipe);
                await _context.SaveChangesAsync();

                return equipe;
        }

        public async Task<bool> RemoverEquipe(int torneioId, int equipeId)
        {
            var torneio = await _context.Torneios.Include(t => t.Equipes).FirstOrDefaultAsync(t => t.Id ==  torneioId);

            if(torneio == null) return false;

            var equipe = await _context.Equipes.FirstOrDefaultAsync(e => e.Id == equipeId);
            
            if(equipe == null) return false;

            torneio.Equipes.Remove(equipe);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Equipe> AlterarEquipe(int torneioId, int equipeId ,Equipe equipe)
        {
            var equipeExiste = await _context.Torneios.Include(e => e.Equipes).FirstOrDefaultAsync(t => t.Id == torneioId);
            if (equipeExiste == null) return null;

            var index = await _context.Equipes.FirstOrDefaultAsync(e => e.Id == equipeId);
            if (index == null) return null;

            index.Nome = equipe.Nome;
            index.TorneioId = equipe.TorneioId;

            _context.Update(index);
            await _context.SaveChangesAsync();

            return index;
        }
    }
}
