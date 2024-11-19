using ProductionOrderSEQUOR.API.Models;

namespace ProductionOrderSEQUOR.API.Interfaces
{
    public interface IUserRepository
    {
        // WEB - INCLUIR / ALTERAR E EXCLUIR

        void Incluir(User user);
        void Alterar(User user);
        void Excluir(User user);
        Task<User> SelecionarByPk(int id);
        Task<IEnumerable<User>> SelecionarTodos();

        Task<bool> SavellAsync(); // mecanismo que vai salvar o método, sendo inclusão, alteração ou exclusão!

    }
}
