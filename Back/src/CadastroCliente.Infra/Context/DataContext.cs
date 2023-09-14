
namespace CadastroCliente.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EnderecoCliente> EnderecosClientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<EnderecoCliente>()
                   .HasKey(EC => new {EC.EnderecoId, EC.ClienteId});
                
        }
    }
}