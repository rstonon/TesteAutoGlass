using MediatR;
using Microsoft.EntityFrameworkCore;
using TesteAutoGlass.Application.ViewModels;
using TesteAutoGlass.Infrastructure.Persistence;

namespace TesteAutoGlass.Application.Queries.GetByIDProduct
{
    public class GetByIDProductQueryHandler : IRequestHandler<GetByIDProductQuery, ProductDetailsViewModel>
    {
        private readonly AutoGlassDbContext _dbContext;
        public GetByIDProductQueryHandler(AutoGlassDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProductDetailsViewModel> Handle(GetByIDProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Codigo == request.Codigo);

            if (product == null) return null;

            var productDetailsViewModel = new ProductDetailsViewModel(
                product.Codigo,
                product.Descricao,
                product.Situacao,
                product.DataFabricacao,
                product.DataValidade,
                product.CodigoFornecedor,
                product.DescricaoFornecedor,
                product.CNPJFornecedor
                );

            return productDetailsViewModel;
        }
    }
}
