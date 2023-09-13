using CadastroCliente.Domain;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Infra
{
    public class CadastroClienteContext : DbContext
    {
        public CadastroClienteContext(DbContextOptions<CadastroClienteContext> options) : base(options){}
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }

        public DbSet<ClienteEnderecoModel> ClientesEnderecos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<ClienteEnderecoModel>()
                .HasKey(CE => new {CE.ClienteId, CE.EnderecoId});
        }
    }
}