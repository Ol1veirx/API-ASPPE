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
        public async Task<Torneio> CriarTorneio(Torneio torneio)
        {
            var novoTorneio = new Torneio
            {
                Nome = torneio.Nome,
                DataInicio = torneio.DataInicio,
                Localizacao = torneio.Localizacao
            };

            _context.Torneios.Add(novoTorneio);
            await _context.SaveChangesAsync();

            return novoTorneio;
        }

        public async Task<Torneio> AlterarTorneio(Torneio torneio)
        {
            var index = await _context.Torneios.FirstOrDefaultAsync(t => t.Id == torneio.Id);

            if (index == null) return null;

            index.Nome = torneio.Nome;
            index.Localizacao = torneio.Localizacao;
            index.DataInicio = torneio.DataInicio;

            _context.Torneios.Update(index);
            await _context.SaveChangesAsync();

            return index;
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
