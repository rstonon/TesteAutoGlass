using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Core.Repositories;
using TesteAutoGlass.Infrastructure.Persistence;

namespace TesteAutoGlass.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _repository;
        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Descricao, request.DataFabricacao, request.DataValidade, request.CodigoFornecedor, request.DescricaoFornecedor, request.CNPJFornecedor);

            await _repository.AddAsync(product);

            return product.Codigo;
        }
    }
}
