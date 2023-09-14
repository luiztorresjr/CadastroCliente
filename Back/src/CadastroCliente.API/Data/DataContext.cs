using CadastroCliente.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}