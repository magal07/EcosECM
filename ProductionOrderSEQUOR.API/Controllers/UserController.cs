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
            var users = await _userRepository.SelecionarTodos();
            var usersDTO = _mapper.Map<IEnumerable<UserDTO>> (users);
            return Ok(usersDTO);
        }
        [HttpPost]
        public async Task<ActionResult> CadastrarUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _userRepository.Incluir(user);
            if (await _userRepository.SavellAsync())
            {
                return Ok("Usuário cadastrado com sucesso!");
            }
            return BadRequest("Ocorreu um erro ao salvar o usuário.");
        }
        [HttpPut]
        public async Task<ActionResult> AlterarUser(UserDTO userDTO)
         {
            if (userDTO.Id == 0)
            {
                return BadRequest("Não é possível alterar o usuário. É preciso informar o Id.");
            }

            var userExiste = await _userRepository.SelecionarByPk(userDTO.Id);
            if (userExiste == null)
            {
                return NotFound("Usuário não encontrado!");
            }

            var user = _mapper.Map<User>(userDTO);
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
                return NotFound("Usuário não encontrado!");
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
