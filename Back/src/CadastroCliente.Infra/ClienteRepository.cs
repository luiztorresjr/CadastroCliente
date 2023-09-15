
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Infra.Context;
using CadastroCliente.Domain.Models;
using CadastroCliente.Infra.Interfaces;

namespace CadastroCliente.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;
        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Cliente[]> GetAllClientsAsync(bool includeEndereco = false){
            IQueryable<Cliente> query = _context.Clientes;
            if (includeEndereco)
            {
                query = query.Include(ce => ce.EnderecosClientes)
                    .ThenInclude(e => e.Endereco);
            }
            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClientByIdAsync(int id, bool includeEndereco = false){
            IQueryable<Cliente> query = _context.Clientes;
            if(includeEndereco){
                query = query
                        .Include(c => c.EnderecosClientes)
                        .ThenInclude(e => e.Endereco);
            }
                 query = query.Where(i => i.Id == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}