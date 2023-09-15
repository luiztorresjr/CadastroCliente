using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.Domain.Models;
using CadastroCliente.Application.Interfaces;
using CadastroCliente.Infra.Interfaces;

namespace CadastroCliente.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IGeralRepository _geral;
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoService(IGeralRepository geral, IEnderecoRepository enderecoRepository)
        {
            _geral = geral;
            _enderecoRepository = enderecoRepository;
        }

         public async Task<Endereco> AddEnderecoAsync(Endereco model){
            _geral.Add<Endereco>(model);
            await _geral.SaveChangesAsync();
            return await _enderecoRepository.GetEnderecoByIdAsync(model.Id);
        }

        public async Task<Endereco> UpdateEnderecoAsync(int id, Endereco model){
            var endereco = await _enderecoRepository.GetEnderecoByIdAsync(id);
            if (endereco == null) return null;
            model.Id = endereco.Id;
            _geral.Update<Endereco>(model);
            var result = await _geral.SaveChangesAsync();
            return await _enderecoRepository.GetEnderecoByIdAsync(model.Id);
        }
        public async Task<bool> DeleteEnderecoAsync(int id){
            var endereco = await _enderecoRepository.GetEnderecoByIdAsync(id);
            if (endereco == null) throw new Exception("endereco para delete não encontrado.");
            _geral.Delete<Endereco>(endereco);
            return await _geral.SaveChangesAsync();
        }
        public async Task<Endereco[]> GetAllEnderecosAsync(){
            var enderecos = await _enderecoRepository.GetAllEnderecosAsync();
            return enderecos;
        }
        public async Task<Endereco> GetEnderecoByIdAsync(int id){
            var enderecos = await _enderecoRepository.GetEnderecoByIdAsync(id);
            return enderecos;
        }

    }
}