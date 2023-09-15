using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.Domain.Models;

namespace CadastroCliente.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco> AddEnderecoAsync(Endereco model);
        Task<Endereco> UpdateEnderecoAsync(int id, Endereco model);
        Task<bool> DeleteEnderecoAsync(int id);
        Task<Endereco[]> GetAllEnderecosAsync();
        Task<Endereco> GetEnderecoByIdAsync(int id );
    }
}