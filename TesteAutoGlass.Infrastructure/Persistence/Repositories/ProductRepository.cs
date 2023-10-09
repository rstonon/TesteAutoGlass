using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Core.Enums;
using TesteAutoGlass.Core.Models;
using TesteAutoGlass.Core.Repositories;

namespace TesteAutoGlass.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private const int PAGE_SIZE = 2;
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

        public async Task<PaginationResult<Product>> GetAllAsync(string descricao, int page)
        {
            IQueryable<Product> products = _dbContext.Products;

            if (!string.IsNullOrWhiteSpace(descricao))
            {
                products = products
                    .Where(p => p.Descricao.Contains(descricao));
            }

            return await products.GetPaged<Product>(page, PAGE_SIZE);
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
