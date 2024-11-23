using ProductionOrderSEQUOR.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Incluir(Product product);
        Task<Product> Alterar(Product product);
        Task<Product> Excluir(int id);
        Task<Product> SelecionarAsync(int id);
        Task<IEnumerable<Product>> SelecionarTodosAsync();
    }
}
