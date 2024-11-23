using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(UserDTO userDTO)
        {
            var userDTOIncluido = await _userService.Incluir(userDTO);
            if (userDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o cliente");
            }
            return Ok("Cliente incluído com sucesso!");
        }

        [HttpPut]
        public async Task<ActionResult> Alterar(UserDTO userDTO)
        {
            var userDTOalterado = await _userService.Alterar(userDTO);
            if (userDTOalterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o cliente");
            }
            return Ok("Cliente alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var userDTOExcluido = await _userService.Excluir(id);
            if (userDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o cliente.");
            }
            return Ok("Cliente excluido com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var userDTO = await _userService.SelecionarAsync(id);
            if (userDTO == null)
            {
                return BadRequest("Cliente não encontrado.");
            }
            return Ok(userDTO);
        }

        [HttpGet]
            public async Task<ActionResult> SelecionarTodos()
        {
            var usersDTO = await _userService.SelecionarTodosAsync();

            return Ok(usersDTO);
        }
    }
}
