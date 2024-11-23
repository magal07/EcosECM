using ProductionOrderSEQUOR.Domain.Entities;
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
    Task<IEnumerable<User>> SelecionarTodosAsync();

    // Task<bool> SaveAllAsync(); // mecanismo que vai salvar o método, sendo inclusão, alteração ou exclusão!

   }
}