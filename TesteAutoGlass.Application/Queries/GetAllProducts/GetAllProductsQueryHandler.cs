using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Application.ViewModels;
using TesteAutoGlass.Infrastructure.Persistence;

namespace TesteAutoGlass.Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
    {
        private readonly AutoGlassDbContext _dbContext;
        public GetAllProductsQueryHandler(AutoGlassDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _dbContext.Products;

            var productsViewModel = await products
                .Select(p => new ProductViewModel(p.Codigo, p.Descricao))
                //.Skip((pageSize - 1) * page)
                //.Take(pageSize)
                .ToListAsync();

            return productsViewModel;
        }
    }
}
