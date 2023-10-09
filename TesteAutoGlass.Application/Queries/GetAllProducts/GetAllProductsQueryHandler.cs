using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Application.ViewModels;
using TesteAutoGlass.Core.Repositories;
using TesteAutoGlass.Infrastructure.Persistence;

namespace TesteAutoGlass.Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _repository;
        public GetAllProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(request.Descricao, request.Situacao, request.Pagina, request.QntRegistrosPorPagina);

            var productsViewModel = products
                .Select(p => new ProductViewModel(p.Codigo, p.Descricao, p.Situacao))
                .Where(p => p.Situacao == Core.Enums.ProductStatusEnum.Ativo)
                //.Skip((pageSize - 1) * page)
                //.Take(pageSize)
                .ToList();

            return productsViewModel;
        }
    }
}
