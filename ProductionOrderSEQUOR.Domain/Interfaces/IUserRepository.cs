using ProductionOrderSEQUOR.Domain.Entities;
using ProductionOrderSEQUOR.Domain.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;


 namespace ProductionOrderSEQUOR.Domain.Interfaces
  {
    public interface IUserRepository
        {
   
            // FUNÇÕES // 
    // WEB - INCLUIR / ALTERAR E EXCLUIR

    Task<User> Incluir(User user);
    Task<User> Alterar(User user);
    Task<User> Excluir(int id);
    Task<User> SelecionarAsync(int id);
    Task<PagedList<User>> SelecionarTodosAsync(int pageNumber, int pageSize);

    // Task<bool> SaveAllAsync(); // mecanismo que vai salvar o método, sendo inclusão, alteração ou exclusão!

   }
}