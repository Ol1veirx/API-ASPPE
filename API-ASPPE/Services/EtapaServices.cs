using API_ASPPE.Data;
using API_ASPPE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ASPPE.Services
{
    public class EtapaServices
    {
        private readonly APContext _context;
        public EtapaServices(APContext context)
        {
            _context = context;
        }

        public async Task<Etapa> ObterEtapaId(int etapaId)
        {
            var etapa = await _context.Etapas.FindAsync(etapaId);

            if (etapa == null) return null;

            return etapa;
        }

        public async Task<Etapa> CriarEtapa(Etapa etapa)
        {
            _context.Etapas.Add(etapa);
            await _context.SaveChangesAsync();
            return etapa;
        }
        public async Task<bool> AtualizarEtapa(int etapaId, Etapa etapa)
        {
            _context.Entry(etapa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoverEtapa(int etapaId)
        {
            var etapa = await _context.Etapas.FindAsync(etapaId);
            if (etapa == null) return false;
            _context.Etapas.Remove(etapa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Etapa> RegistrarResultadoEtapa(int torneioId, string nome)
        {
            var torneioExiste = await _context.Torneios.FirstOrDefaultAsync(t => t.Id == torneioId);
            /*var equipeExiste = await _context.Equipes.FirstOrDefaultAsync(e => e.Id == equipeId);*/

            if (torneioExiste == null /*|| equipeExiste == null*/) return null;

            var novaEtapa = new Etapa
            {
                Nome = nome,
                TorneioId = torneioId,
               /* QuantidadePeixe = quantidadePeixe,
                Peso = peso,
                Pontuacao = pontuacao,*/
            };

            _context.Etapas.Add(novaEtapa);
            await _context.SaveChangesAsync();

            return novaEtapa;
        }
        public async Task<bool> AdicionarEquipeDaEtapa(int etapaId, int equipeId)
        {
            var etapa = await _context.Etapas.Include(e => e.EquipesParticipantes).FirstOrDefaultAsync(e => e.Id == etapaId);
            var equipe = await _context.Equipes.FindAsync(equipeId);

            if (etapa == null || equipe == null) return false;

            etapa.EquipesParticipantes.Add(new EquipeEtapa { EquipeId = equipeId, EtapaId = etapaId });
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoverEquipeDaEtapa(int etapaId, int equipeId)
        {
            var etapa = await _context.Etapas.Include(e => e.EquipesParticipantes).FirstOrDefaultAsync(e => e.Id == etapaId);
            var equipe = await _context.Equipes.FindAsync(equipeId);

            if (etapa == null || equipe == null) return false;

            var equipeEtapa = etapa.EquipesParticipantes.FirstOrDefault(e => e.EquipeId == equipeId);
            if (equipeEtapa == null) return false;
            etapa.EquipesParticipantes.Remove(equipeEtapa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
