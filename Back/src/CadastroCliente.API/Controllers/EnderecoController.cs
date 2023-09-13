using System.Collections.Generic;
using System.Linq;
using CadastroCliente.Infra;
using CadastroCliente.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly CadastroClienteContext _context;
        public EnderecoController(CadastroClienteContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void PostEndereco([FromBody] EnderecoModel endereco){
            _context.Enderecos.Add(endereco);        
        }

        [HttpGet]
        public IEnumerable<EnderecoModel> GetEnderecos(){
            var endereco = _context.Enderecos;            
            return endereco;
        }

        [HttpGet("{id}")]
        public EnderecoModel GetEndereco(int id){
            var endereco = _context.Enderecos.Where(i => i.Id == id).First();
            return endereco;        
        }

        [HttpPut("{id}")]
        public EnderecoModel PutEndereco(int id, [FromBody] EnderecoModel endereco){
            EnderecoModel enderecoParaAtualizar = _context.Enderecos.Where(i => i.Id == id).FirstOrDefault();
            if(enderecoParaAtualizar == null){
                return null;
            }
            enderecoParaAtualizar = endereco;
            return enderecoParaAtualizar;
        }

        [HttpDelete("{id}")]
        public string DeletarEndereco(int id){
            EnderecoModel endereco = _context.Enderecos.Where(i => i.Id == id).FirstOrDefault();
            if(endereco == null){
                return "Cliente não encontrado";
            }
            _context.Enderecos.Remove(endereco);
            return "Cliente removido com sucesso";
        }
    }
}
