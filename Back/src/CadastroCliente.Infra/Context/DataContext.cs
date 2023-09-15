using Microsoft.EntityFrameworkCore;
using CadastroCliente.Domain.Models;

namespace CadastroCliente.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EnderecoCliente> EnderecosClientes { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnderecoCliente>()
                .HasKey(PE => new {PE.ClienteId, PE.EnderecoId});


            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.EnderecosClientes)
                .WithOne(rs => rs.Cliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}