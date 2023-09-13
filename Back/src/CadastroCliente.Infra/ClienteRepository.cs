using CadastroCliente.Domain;
using CadastroCliente.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CadastroCliente.Infra
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly CadastroClienteContext _context;
        public ClienteRepository(CadastroClienteContext context)
        {
            _context = context;
        }
       
        public async Task<ClienteModel[]?> GetAllClientesAsync(bool includeEndereco =  false){
            IQueryable<ClienteModel> query = _context.Clientes;
            if (includeEndereco)
            {
                query = query.Include(ce => ce.ClientesEnderecos)
                    .ThenInclude(e => e.Endereco);
            }
            return await query.ToArrayAsync();
        }
        public async Task<ClienteModel?> GetClienteByIdAsync(int ClienteId, bool includeEndereco = false){
            IQueryable<ClienteModel> query = _context.Clientes;
            if (includeEndereco)
            {
                query = query.Include(ce => ce.ClientesEnderecos)
                    .ThenInclude(e => e.Endereco);
            }
            query = query.Where(i => i.Id == ClienteId);
            return await query.FirstOrDefaultAsync();
        }
    }
}