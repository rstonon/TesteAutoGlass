using MediatR;
using TesteAutoGlass.Application.ViewModels;
using TesteAutoGlass.Core.Models;
using TesteAutoGlass.Core.Repositories;

namespace TesteAutoGlass.Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginationResult<ProductViewModel>>
    {
        private readonly IProductRepository _repository;
        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<PaginationResult<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var paginationProducts = await _repository.GetAllAsync(request.Descricao, request.Page);

            var productsViewModel = paginationProducts
                .Data
                .Select(p => new ProductViewModel(p.Codigo, p.Descricao))
                .ToList();

            var paginationProductsViewModel = new PaginationResult<ProductViewModel>(
                paginationProducts.Page,
                paginationProducts.TotalPages,
                paginationProducts.PageSize,
                paginationProducts.TotalPages,
                productsViewModel
                );

            return paginationProductsViewModel;
        }
    }
}
