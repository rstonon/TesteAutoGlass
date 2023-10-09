using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Core.Enums;
using TesteAutoGlass.Core.Models;

namespace TesteAutoGlass.Core.Repositories
{
    public interface IProductRepository
    {
        Task<PaginationResult<Product>> GetAllAsync(string descricao, int page = 1);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task SaveChangesAsync();
    }
}
