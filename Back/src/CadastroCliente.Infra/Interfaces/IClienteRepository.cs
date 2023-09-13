using CadastroCliente.Domain;

namespace CadastroCliente.Infra.Interfaces
{
    public interface IClienteRepository
    {
        Task<ClienteModel[]> GetAllClientesAsync(bool includeEndereco);
        Task<ClienteModel> GetClienteByIdAsync(int clienteId, bool includeEndereco);
    }
}
