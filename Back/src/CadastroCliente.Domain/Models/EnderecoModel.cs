    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCliente.Domain
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ddd {get; set; }
        public IEnumerable<ClienteEnderecoModel>? ClientesEnderecos { get; set;}
    }
}