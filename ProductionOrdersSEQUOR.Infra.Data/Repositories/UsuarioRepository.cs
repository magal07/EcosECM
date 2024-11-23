using Microsoft.EntityFrameworkCore;
using ProductionOrderSEQUOR.Domain.Entities;
using ProductionOrderSEQUOR.Domain.Interfaces;
using ProductionOrderSEQUOR.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionOrderSEQUOR.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;


        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Usuario> Incluir(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }


        public async Task<Usuario> Alterar(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }


        public async Task<Usuario> Excluir(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            return usuario;
        }


        public async Task<Usuario> SelecionarByPk(int id)
        {
            var usuario = await _context.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            return usuario;
        }


        public async Task<IEnumerable<Usuario>> SelecionarTodosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }


        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Usuario> SelecionarAsync(int id)
        {
           return await _context.Usuario.FirstOrDefaultAsync( u => u.Id == id);
        }
    }
}
