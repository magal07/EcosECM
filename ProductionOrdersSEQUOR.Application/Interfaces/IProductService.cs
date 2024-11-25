using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> Incluir(ProductDTO productDTO);
        Task<ProductDTO> Alterar(ProductDTO productDTO);
        Task<ProductDTO> Excluir(int id);
        Task<ProductDTO> SelecionarAsync(int id);
        Task<IEnumerable<ProductDTO>> SelecionarTodosAsync();

    }
}
