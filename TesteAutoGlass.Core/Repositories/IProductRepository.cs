using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Core.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(string descricao, ProductStatusEnum situacao, int pagina, int registrosPorPagina);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task SaveChangesAsync();
    }
}
