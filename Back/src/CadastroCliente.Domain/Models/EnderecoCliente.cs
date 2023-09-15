using System;

namespace CadastroCliente.Domain.Models{
    public class EnderecoCliente
    {
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
    }
}
