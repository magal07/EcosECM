using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductionOrderSEQUOR.API.Interfaces;
using ProductionOrderSEQUOR.API.Models;

namespace ProductionOrderSEQUOR.API.Repositories
{
    // MÉTODOS DA INTERFACE: 

    public class UserRepository : IUserRepository
    {
        private readonly ControleProductionOrderContext _context;

        public UserRepository(ControleProductionOrderContext context)
        {
            _context = context;
        }

        public void Alterar(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Excluir(User user)
        {
            _context.User.Remove(user);
        }

        public void Incluir(User user)
        {
            _context.User.Add(user);
        }

        public async Task<bool> SavellAsync()
        {
            return await _context.SaveChangesAsync() > 0; // SE FOR MAIOR QUE 0, SALVOU A INSTÂNCIA, CASO CONTRÁRIO RETORNARÁ FALSE COM ALGUM ERRO! (Geralmente erro de DB)
        }

        public async Task<User> SelecionarByPk(int id)
        {
            var user = await _context.User.Where(x => x.Id == id).FirstOrDefaultAsync();    // await -> se não ele retorna a task ao invés do usuário
            if (user == null)
            {
                // Retorne um valor padrão, ou lançar uma exceção
                // Por exemplo:
                throw new Exception("Usuário não encontrado!");
            }

            return user;
        }

        public async Task<IEnumerable<User>> SelecionarTodos()
        {
            return await _context.User.ToListAsync();
        }

    }

}
