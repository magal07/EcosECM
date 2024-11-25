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
    public class ProductionRepository : IProductionRepository
    {
        private readonly ApplicationDbContext _context;


        public ProductionRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Production> Incluir(Production production)
        {
            _context.Production.Add(production);
            await _context.SaveChangesAsync();
            return production;
        }



        public async Task<Production> Alterar(Production production)
        {
            _context.Production.Update(production);
            await _context.SaveChangesAsync();
            return production;
        }


        public async Task<Production> Excluir(int id)
        {
            var production = await _context.Production.FindAsync(id);
            if (production != null)
            {
                _context.Production.Remove(production);
                await _context.SaveChangesAsync();
            }
            return production;
        }


        public async Task<Production> SelecionarAsync(int id)
        {
            var production = await _context.Production.Include(x => x.User).Include(x => x.Product).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (production == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            return production;
        }


        public async Task<IEnumerable<Production>> SelecionarTodosAsync()
        {
            return await _context.Production.Include(x => x.User).Include(x => x.Product).ToListAsync();
        }


        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
