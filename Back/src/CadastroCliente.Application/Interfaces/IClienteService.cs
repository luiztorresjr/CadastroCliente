using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.Domain.Models;

namespace CadastroCliente.Application.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> AddClientAsync(Cliente model);
        Task<Cliente> UpdateClientAsync(int id, Cliente model);
        Task<bool> DeleteClientAsync(int id);
        Task<Cliente[]> GetAllClientsAsync(bool includeEndereco = false);
        Task<Cliente> GetClientByIdAsync(int id, bool includeEndereco = false);
    }
}