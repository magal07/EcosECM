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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Incluir(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<Product> Alterar(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }


        public async Task<Product> Excluir(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
            }
            return product;
        }


        public async Task<Product> SelecionarByPk(int id)
        {
            var product = await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            return product;
        }


        public async Task<IEnumerable<Product>> SelecionarTodosAsync()
        {
            return await _context.Product.ToListAsync();
        }


        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Product> SelecionarAsync(int id)
        {
            return await _context.Product.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
