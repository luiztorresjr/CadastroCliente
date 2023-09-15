using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Infra.Context;
using CadastroCliente.Domain.Models;
using CadastroCliente.Infra.Interfaces;

namespace CadastroCliente.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private DataContext _context;
        public EnderecoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Endereco[]> GetAllEnderecosAsync(){
            IQueryable<Endereco> query = _context.Enderecos;
            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Endereco> GetEnderecoByIdAsync(int id){
             IQueryable<Endereco> query = _context.Enderecos;
            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Id == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}