using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Application.Interfaces;
using ProductionOrderSEQUOR.Infra.Ioc;

namespace ProductionOrderSEQUOR.API.Controllers
{
    [ApiController]
    [Route("API/Orders/GetProduct")]
    [Authorize]
    public class ProductController : Controller

    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]

        public async Task<ActionResult> Incluir(ProductDTO productDTO)
        {
            
            var productDTOIncluido = await _productService.Incluir(productDTO);
            if (productDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o produto");
            }
            return Ok("Produto incluído com sucesso!");
        }

        [HttpPut]

        public async Task<ActionResult> Alterar(ProductDTO productDTO)
        {
            var productDTOalterado = await _productService.Alterar(productDTO);
            if (productDTOalterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o produto");
            }
            return Ok("Produto alterado com sucesso!");
        }

        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {            

            var productDTOExcluido = await _productService.Excluir(id);
            if (productDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o produto.");
            }
            return Ok("Produto excluido com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var productDTO = await _productService.SelecionarAsync(id);
            if (productDTO == null)
            {
                return BadRequest("Produto não encontrado.");
            }
            return Ok(productDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos()
        {
            var productsDTO = await _productService.SelecionarTodosAsync();

            return Ok(productsDTO);
        
     }
    }
}
