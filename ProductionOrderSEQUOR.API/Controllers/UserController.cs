using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.API.Interfaces;
using ProductionOrderSEQUOR.API.Models;
using ProductionOrderSEQUOR.API.Repositories;

namespace ProductionOrderSEQUOR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // CRIANDO ROTA
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
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
            if(await _userRepository.SavellAsync())
            {
                return Ok("Cliente cadastrado com sucesso!"); 
            }
            return BadRequest("Ocorreu um erro ao salvar o cliente.");
        }
    }
}
