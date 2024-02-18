using API_ASPPE.Data;
using API_ASPPE.Models;
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

        public async Task<Etapa> RegistrarResultadoEtapa(int torneioId, int equipeId, int quantidadePeixe, double peso, double pontuacao)
        {
            var torneioExiste = await _context.Torneios.FirstOrDefaultAsync(t => t.Id == torneioId);
            var equipeExiste = await _context.Equipes.FirstOrDefaultAsync(e => e.Id == equipeId);

            if (torneioExiste == null || equipeExiste == null) return null;

            var novaEtapa = new Etapa
            {
                TorneioId = torneioId,
                EquipeId = equipeId,
                QuantidadePeixe = quantidadePeixe,
                Peso = peso,
                Pontuacao = pontuacao,
            };

            _context.Etapas.Add(novaEtapa);
            await _context.SaveChangesAsync();

            return novaEtapa;
        }
    }
}
