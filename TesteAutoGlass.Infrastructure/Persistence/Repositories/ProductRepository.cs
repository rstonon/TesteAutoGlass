using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Core.Enums;
using TesteAutoGlass.Core.Repositories;

namespace TesteAutoGlass.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AutoGlassDbContext _dbContext;
        public ProductRepository(AutoGlassDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<Product>> GetAllAsync(string descricao, ProductStatusEnum situacao, int pagina, int registrosPorPagina)
        {
            return await _dbContext.Products
                .Where(p => p.Descricao.Contains(descricao))
                .Where(p => p.Situacao == situacao)
                .AsNoTracking()
                .Skip(pagina)
                .Take(registrosPorPagina)
                .ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Codigo == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
