using CadastroCliente.Domain.Models;
using CadastroCliente.Application.Interfaces;
using CadastroCliente.Infra.Interfaces;

namespace CadastroCliente.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IGeralRepository baseRepository, IClienteRepository repository)
        {
            _geralRepository = baseRepository;
            _clienteRepository = repository;
        }
        public async Task<Cliente> AddClientAsync(Cliente model)
        {
            try
            {
                _geralRepository.Add<Cliente>(model);
                if(await _geralRepository.SaveChangesAsync())
                {
                    return await _clienteRepository.GetClientByIdAsync(model.Id, false);
                }
                return null;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

         public async Task<Cliente> UpdateClientAsync(int id, Cliente model)
        {
            try
            {
                var cliente = await _clienteRepository.GetClientByIdAsync(id, false);
                if (cliente == null) return null;

                model.Id = cliente.Id;

                _geralRepository.Update(model);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _clienteRepository.GetClientByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente[]> GetAllClientsAsync(bool includeEndereco = false)
        {
            try
            {
                var clientes = await _clienteRepository.GetAllClientsAsync(includeEndereco);
                if (clientes == null) return null;
                return clientes;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Cliente> GetClientByIdAsync(int clienteId, bool includeEndereco = false)
        {
            try
            {
                var cliente = await _clienteRepository.GetClientByIdAsync(clienteId, includeEndereco);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteClientAsync(int clienteId)
        {
            try
            {
                var cliente = await _clienteRepository.GetClientByIdAsync(clienteId, false);
                if (cliente == null) throw new Exception("Cliente para delete nao foi encontrado.");

                _geralRepository.Delete<Cliente>(cliente);
                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}