using CadastroCliente.Domain;
using CadastroCliente.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Infra
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly CadastroClienteContext _context;
        public EnderecoRepository(CadastroClienteContext context)
        {
            _context = context;
        }

        public async Task<EnderecoModel[]> GetAllEnderecosAsync(bool includeCliente = false)
        {
            IQueryable<EnderecoModel> query = _context.Enderecos;
            return await query.ToArrayAsync();
        }

        public async Task<EnderecoModel?> GetEnderecoByIdAsync(int enderecoId, bool includeCliente = false)
        {
            IQueryable<EnderecoModel> query = _context.Enderecos;
            query = query.Where(i => i.Id == enderecoId);
            return await query.FirstOrDefaultAsync();
        }
    }
}
