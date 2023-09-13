using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCliente.Domain
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public IEnumerable<ClienteEnderecoModel>? ClientesEnderecos { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        
    }
}