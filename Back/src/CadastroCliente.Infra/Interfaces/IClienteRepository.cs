using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.Domain.Models;

namespace CadastroCliente.Infra.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente[]> GetAllClientsAsync(bool includeCliente = false);
        Task<Cliente> GetClientByIdAsync(int id, bool includeCliente = false);
    }
}