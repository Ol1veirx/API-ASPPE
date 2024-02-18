using System.Runtime.InteropServices;
using API_ASPPE.Data;
using API_ASPPE.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ASPPE.Services
{
    public class TorneioServices
    {
        private readonly APContext _context; 
        public TorneioServices(APContext context)
        {
            _context = context;
        }
        public async Task<Torneio> CriarTorneio(string nome, DateTime dataInicio, string localizacao)
        {
            var novoTorneio = new Torneio
            {
                Nome = nome,
                DataInicio = dataInicio,
                Localizacao = localizacao
            };

            _context.Torneios.Add(novoTorneio);
            await _context.SaveChangesAsync();

            return novoTorneio;
        }

        public async Task<Torneio> AlterarTorneio(Torneio torneio,int? torneioId)
        {
            var torneioExisting = await _context.Torneios.FirstOrDefaultAsync(t => t.Id == torneioId);

            if (torneioExisting == null) return null;

            torneioExisting.Nome = torneio.Nome;
            torneioExisting.Localizacao = torneio.Localizacao;
            torneioExisting.DataInicio = torneio.DataInicio;

            _context.Torneios.Update(torneioExisting);
            await _context.SaveChangesAsync();

            return torneioExisting;
        }

        public void ExcluirTorneio(int? id)
        {
            var torneio = _context.Torneios.FirstOrDefault(t => t.Id == id);
            if (torneio != null)
            {
                _context.Torneios.Remove(torneio);
                _context.SaveChanges();
            }
        }
        public async Task<Torneio> DetalheTorneio(int? id)
        {
            return await _context.Torneios.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Torneio>> ListarTorneios()
        {
            return await _context.Torneios.ToListAsync();
        }
    }
}
