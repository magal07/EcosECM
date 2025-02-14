﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductionOrderSEQUOR.Application.Interfaces;
using ProductionOrderSEQUOR.Application.Services;
using ProductionOrderSEQUOR.Domain.Entities;
using ProductionOrderSEQUOR.Domain.Interfaces;
using ProductionOrderSEQUOR.Domain.Pagination;
using ProductionOrderSEQUOR.Infra.Data.Context;
using ProductionOrderSEQUOR.Infra.Data.Helpes;

namespace ProductionOrderSEQUOR.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        
        public UserRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        
        public async Task<User> Incluir(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();  
            return user;  
        }

        
        public async Task<User> Alterar(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();  
            return user;  
        }

        
        public async Task<User> Excluir(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();  
            }
            return user;  
        }

        
        public async Task<User> SelecionarByPk(int id)
        {
            var user = await _context.User.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            return user;  
        }

        
        public async Task<PagedList<User>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.User.AsQueryable();
          return await   PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;  
        }

        public async Task<User> SelecionarAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
