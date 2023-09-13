using CadastroCliente.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteModel> AddCliente(ClienteModel cliente);
        Task<ClienteModel> UpdateCliente(int clienteId, ClienteModel cliente);
        Task<bool> DeleteCliente(int clienteId);
        Task<ClienteModel[]> GetAllClientesAsync(bool includeEndereco = false);
        Task<ClienteModel> GetClienteByIdAsync(int ClienteId, bool includeEndereco = false);
    }
}
