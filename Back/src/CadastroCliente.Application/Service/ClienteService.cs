using CadastroCliente.Application.Interfaces;
using CadastroCliente.Domain;
using CadastroCliente.Infra.Interfaces;

namespace CadastroCliente.Application.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IClienteRepository _repository;

        public ClienteService(IBaseRepository baseRepository, IClienteRepository repository)
        {
            _baseRepository = baseRepository;
            _repository = repository;
        }
        public async Task<ClienteModel?> AddCliente(ClienteModel model)
        {
            try
            {
                _baseRepository.Add<ClienteModel>(model);
                if(await _baseRepository.SaveChangeAsync())
                {
                    return await _repository.GetClienteByIdAsync(model.Id, false);
                }
                return null;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteModel?> UpdateCliente(int clienteId, ClienteModel model)
        {
            try
            {
                var cliente = await _repository.GetClienteByIdAsync(clienteId, false);
                if (cliente == null) return null;
                _baseRepository.Update(model);
                if (await _baseRepository.SaveChangeAsync())
                {
                    return await _repository.GetClienteByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteModel[]?> GetAllClientesAsync(bool includeEndereco = false)
        {
            try
            {
                var clientes = await _repository.GetAllClientesAsync(includeEndereco);
                if (clientes == null) return null;
                return clientes;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteModel> GetClienteByIdAsync(int clienteId, bool includeEndereco = false)
        {
            try
            {
                var cliente = await _repository.GetClienteByIdAsync(clienteId, includeEndereco);
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCliente(int clienteId)
        {
            try
            {
                var cliente = await _repository.GetClienteByIdAsync(clienteId, false);
                if (cliente == null) throw new Exception("Cliente para delete nao foi encontrado.");

                _baseRepository.Delete<ClienteModel>(cliente);
                return await _baseRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
