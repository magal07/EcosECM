using ProductionOrderSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Domain.Interfaces
{
    public interface IProductionRepository
    {
        Task<Production> Incluir(Production production);
        Task<Production> Alterar(Production production);
        Task<Production> Excluir(int id);
        Task<Production> SelecionarAsync(int id);
        Task<IEnumerable<Production>> SelecionarTodosAsync();
    }
}
