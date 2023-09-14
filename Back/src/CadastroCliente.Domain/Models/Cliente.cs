using System;
using System.Collections.Generic;

namespace CadastroCliente.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<EnderecoCliente> EnderecosCliente {get; set;}        
    }
}