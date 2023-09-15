using Microsoft.AspNetCore.Mvc;
using CadastroCliente.Application.Interfaces;
using CadastroCliente.Domain.Models;

namespace CadastroCliente.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private IClienteService _service;
        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var result =  await _service.GetAllClientsAsync(true);
            if(result == null) return NotFound("Não foram encontrados clientes");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id){
            var result =  await _service.GetClientByIdAsync(id, true);
            if(result == null) return NotFound("Não foi encontrado o cliente");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente model)
        {
            try
            {
                var evento = await _service.AddClientAsync(model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente model)
        {
            try
            {
                var result = await _service.UpdateClientAsync(id, model);
                if (result == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var result =  await _service.DeleteClientAsync(id);
            if(result == false) return NotFound("Não foi encontrado o cliente");
            return Ok("Deletado com sucesso");
        }

    }
}