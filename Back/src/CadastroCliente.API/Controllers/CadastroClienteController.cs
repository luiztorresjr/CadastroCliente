using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.API.Data;
using CadastroCliente.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CadastroCliente.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroClienteController : ControllerBase
    {
        private readonly DataContext _context;
        public CadastroClienteController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void PostCliente([FromBody] Cliente cliente){
            _context.Add(cliente);        
        }

        [HttpGet]
        public IEnumerable<Cliente> GetCliente(){
            var clientes = _context.Clientes; 
            var endereco = _context.Enderecos;
            clientes.ForEachAsync(i => i.Enderecos = endereco.Where(e => e.ClienteId == i.Id).ToList());
            return clientes;
        }

        [HttpGet("{id}")]
        public Cliente GetCliente(int id){
            var Endereco = _context.Enderecos.Where(i => i.ClienteId == id);
            var cliente = _context.Clientes.Where(i => i.Id == id).FirstOrDefault();
            cliente.Enderecos = Endereco.ToList();
            return cliente;        
        }

        [HttpPut("{id}")]
        public Cliente PutCliente(int id, [FromBody] Cliente cliente){
            Cliente clienteParaAtualizar = _context.Clientes.Where(i => i.Id == id).FirstOrDefault();
            if(cliente == null){
                return null;
            }
            clienteParaAtualizar = cliente;
            return clienteParaAtualizar;
        }

        [HttpDelete("{id}")]
        public string DeletarCliente(int id){
            Cliente cliente = _context.Clientes.Where(i => i.Id == id).FirstOrDefault();
            if(cliente == null){
                return "Cliente não encontrado";
            }
            _context.Clientes.Remove(cliente);
            return "Cliente removido com sucesso";
        }
    }
}
