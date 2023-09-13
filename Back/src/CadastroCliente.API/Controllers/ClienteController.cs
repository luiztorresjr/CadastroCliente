using System.Collections.Generic;
using System.Linq;
using CadastroCliente.Infra;
using CadastroCliente.Domain;
using Microsoft.AspNetCore.Mvc;
using CadastroCliente.Application.Interfaces;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace CadastroCliente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _service.GetAllClientesAsync(true);
                if(clientes == null)
                {
                    return NotFound("Nenhum clientes encontrados.");
                }
                return Ok(clientes);
            }catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao tentar recuperar clientes, Erro: {ex.Message}.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cliente = await _service.GetClienteByIdAsync(id, true);
                if (cliente == null)
                {
                    return NotFound("Nenhum cliente encontrado.");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cliente, Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteModel model)
        {
            try
            {
                var cliente = await _service.AddCliente(model);
                if (cliente == null)
                {
                    return BadRequest("Erro ao tentar adicionar Cliente");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cliente, Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int clienteId, ClienteModel model)
        {
            try
            {
                var cliente = await _service.UpdateCliente(clienteId, model);
                if (cliente == null)
                {
                    return BadRequest("Erro ao tentar adicionar Cliente");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cliente, Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int clienteId)
        {
            try
            {
                return await _service.DeleteCliente(clienteId) ? Ok("Deletado com sucesso") : BadRequest("Cliente nao deletado");                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar cliente, Erro: {ex.Message}");
            }
        }

    }
}
