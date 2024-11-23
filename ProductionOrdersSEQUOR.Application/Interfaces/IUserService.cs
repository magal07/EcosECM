using ProductionOrderSEQUOR.Application.DTOs;
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
        Task<IEnumerable<UserDTO>> SelecionarTodos();

        Task<bool> SavellAsync(); // mecanismo que vai salvar o método, sendo inclusão, alteração ou exclusão!
        Task SelecionarTodosAsync(int id);
    }
}
