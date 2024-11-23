using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Incluir(UserDTO userDTO);
        Task<UserDTO> Alterar(UserDTO userDTO);
        Task<UserDTO> Excluir(int id);
        Task<UserDTO> SelecionarAsync(int id);
        Task<IEnumerable<UserDTO>> SelecionarTodosAsync();

        // Task<bool> SaveAllAsync(); // mecanismo que vai salvar o método, sendo inclusão, alteração ou exclusão!
    }
}
