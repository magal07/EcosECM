using ProductionOrderSEQUOR.Application.DTOs;
using ProductionOrderSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Application.Interfaces
{
    public interface IProductionService
    {
        Task<ProductionDTO> Incluir(ProductionPostDTO productionPostDTO);
        Task<ProductionDTO> Alterar(ProductionDTO productionDTO);
        Task<ProductionDTO> Excluir(int id);
        Task<ProductionDTO> SelecionarAsync(int id);
        Task<IEnumerable<ProductionDTO>> SelecionarTodosAsync();
        // Task<bool> VerificaDisponibilidadeAsync(int idProduct);

    }
}
