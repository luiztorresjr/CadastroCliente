using System.Threading.Tasks;
using CadastroCliente.Infra.Context;
using CadastroCliente.Infra.Interfaces;

namespace CadastroCliente.Infra.Repositories
{
    public class GeralRepository : IGeralRepository
    {
        private readonly DataContext _context;
        public GeralRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }       
        
    }
}