using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.Domain.Models;

namespace CadastroCliente.Infra.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco[]> GetAllEnderecosAsync();
        Task<Endereco> GetEnderecoByIdAsync(int id);

    }
}