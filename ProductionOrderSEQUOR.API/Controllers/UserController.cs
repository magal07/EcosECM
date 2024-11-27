using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.API.Extensions;
using ProductionOrderSEQUOR.API.Models;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Application.Interfaces;
using ProductionOrderSEQUOR.Infra.Ioc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // -> só usuários autenticados conseguirão acessar clientes e gerar mudanças 
    [Authorize]


                                             //~ USER = > Cliente. ~//
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUsuarioService _usuarioService;

        public UserController(IUserService userService, IUsuarioService usuarioService)
        {
            _userService = userService;
            _usuarioService = usuarioService;   
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

        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            var userId = User.GetId();

            var usuario = await _usuarioService.SelecionarAsync(userId);
            if (!usuario.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para excluir clientes!");
            }

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
            public async Task<ActionResult> SelecionarTodos([FromQuery]PaginationParams paginationParms)
        {
            var usersDTO = await _userService.SelecionarTodosAsync
                (paginationParms.PageNumber, paginationParms.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(usersDTO.CurrentPage, usersDTO.PageSize,
                usersDTO.TotalCount, usersDTO.TotalPages));

            return Ok(usersDTO);
        }    
    }
}
