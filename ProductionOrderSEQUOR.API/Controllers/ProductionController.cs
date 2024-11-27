using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Infra.Ioc;
using ProductionOrderSEQUOR.Application.Interfaces;

namespace PproductionOrderSEQUOR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // -> só usuários autenticados conseguirão acessar clientes e gerar mudanças
    [Authorize]
    public class ProductionController : Controller
    {

        private readonly IProductionService _productionService;
        private readonly IUsuarioService _usuarioService;
        private readonly IUserService _userService;

        public ProductionController(IProductionService productionService, IUsuarioService usuarioService, IUserService userService)
        {
            _productionService = productionService;
            _usuarioService = usuarioService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Incluir(ProductionPostDTO productionPostDTO)
        {
            
            productionPostDTO.Date = DateTime.Now;

            
            productionPostDTO.DateEnd = productionPostDTO.Date.AddMinutes(1);

            // Calcula o CycleTime (diferença em minutos)
            productionPostDTO.CycleTime = (decimal)(productionPostDTO.DateEnd - productionPostDTO.Date).TotalMinutes;

            
            var productionDTOIncluido = await _productionService.Incluir(productionPostDTO);

            
            if (productionDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir a produção.");
            }

            return Ok("Produção incluída com sucesso!");
        }

        [HttpPut]

        public async Task<ActionResult> Alterar(ProductionPutDTO productionPutDTO)
        {
            var productionDTO = await _productionService.SelecionarAsync(productionPutDTO.Id);
            if (productionDTO == null)
            {
                return NotFound("Produção não encontrada.");
            }

            productionDTO.Email = productionPutDTO.Email;
            productionDTO.Quantity = productionPutDTO.Quantity; 

            var productionDTOalterado = await _productionService.Alterar(productionDTO);
            if (productionDTOalterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar a produção.");
            }
            return Ok("Produção alterada com sucesso!");
        }

        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {

            var productionDTOExcluido = await _productionService.Excluir(id);
            if (productionDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir a produção.");
            }
            return Ok("Produção excluida com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> SelecionarAsync(int id)
        {
            var production = await _productionService.SelecionarAsync(id);
            if (production == null)
            {
                return BadRequest("Produção não encontrada.");
            }
            return Ok(production);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos()
        {
            var productionsDTO = await _productionService.SelecionarTodosAsync();

            return Ok(productionsDTO);
        }
    }
}
