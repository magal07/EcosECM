using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.API.DTOs;
using ProductionOrderSEQUOR.API.Interfaces;
using ProductionOrderSEQUOR.API.Models;
using ProductionOrderSEQUOR.API.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // CRIANDO ROTA
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
              
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return Ok(await _userRepository.SelecionarTodos());
        }
        [HttpPost]
        public async Task<ActionResult> CadastrarUser(User user)
        {
            _userRepository.Incluir(user);
            if (await _userRepository.SavellAsync())
            {
                return Ok("Usuário cadastrado com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao salvar o usuário.");
        }
        [HttpPut]
        public async Task<ActionResult> AlterarUser(User user)
        {
            _userRepository.Alterar(user);
            if (await _userRepository.SavellAsync())
            {
                return Ok("Usuário alterado com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao alterar o usuário.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirUser(int id)
        {
            var user = await _userRepository.SelecionarByPk(id);

            if (user == null)
            {
                return NotFound("Cliente não encontrado!");
            }
            _userRepository.Excluir(user);
            if (await _userRepository.SavellAsync())
            {
                return Ok("Usuário excluído com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao excluir o usuário.");
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> SelecionarUser(int id)
        {
            var user = await _userRepository.SelecionarByPk(id);

            if (user == null)
            {

                return NotFound("User não encontrado.!");
            }

            var UserDTO = _mapper.Map<UserDTO>(user);

            return Ok(UserDTO);

        }
    }
}
