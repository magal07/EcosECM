using AutoMapper;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Application.Interfaces;
using ProductionOrderSEQUOR.Domain.Entities;
using ProductionOrderSEQUOR.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository; 
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Alterar(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var usuarioAlterado = await _repository.Alterar(usuario);
            return _mapper.Map<UsuarioDTO>(usuarioAlterado);
        }

        public async Task<UsuarioDTO> Excluir(int id)
        {
            var usuario = await _repository.Excluir(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var usuarioIncluido = await _repository.Incluir(usuario);
            return _mapper.Map<UsuarioDTO>(usuarioIncluido);
        }

        public async Task<UsuarioDTO> SelecionarAsync(int id)
        {
            var usuario = await _repository.SelecionarAsync(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<IEnumerable<UsuarioDTO>> SelecionarTodosAsync()
        {
            var usuarios = await _repository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }
    }
}
