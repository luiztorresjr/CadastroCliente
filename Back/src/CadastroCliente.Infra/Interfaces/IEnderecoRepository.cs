using CadastroCliente.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Infra.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<EnderecoModel[]> GetAllEnderecosAsync(bool includeCliente);
        Task<EnderecoModel> GetEnderecoByIdAsync(int enderecoId, bool includeCliente);

    }
}
