using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Application.Interfaces;
using ProductionOrderSEQUOR.Domain.Entities;
using ProductionOrderSEQUOR.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Alterar(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var userAlterado = await _repository.Alterar(user);
            return _mapper.Map<UserDTO>(userAlterado);
        }

        public async Task<UserDTO> Excluir(int id)
        {
            var userExcluido = await _repository.Excluir(id);
            return _mapper.Map<UserDTO>(userExcluido);
        }

        public async Task<UserDTO> Incluir(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var userIncluido = await _repository.Incluir(user);
            return _mapper.Map<UserDTO>(userIncluido);
        }

        public async Task<UserDTO> SelecionarAsync(int id)
        {
            var user = await _repository.SelecionarAsync(id);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<IEnumerable<UserDTO>> SelecionarTodosAsync()
        {
            var users = await _repository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }   
    }
}