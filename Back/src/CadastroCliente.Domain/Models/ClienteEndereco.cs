using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCliente.Domain
{
    public class ClienteEnderecoModel
    {
        public int Id {get; set;}
        public int ClienteId {get; set;}
        public ClienteModel Cliente {get; set;}
        public int EnderecoId {get; set;}
        public EnderecoModel Endereco {get; set;}
        public int Numero {get; set;}
    }
}