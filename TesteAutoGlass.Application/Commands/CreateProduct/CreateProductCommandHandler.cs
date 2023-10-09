using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Infrastructure.Persistence;

namespace TesteAutoGlass.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly AutoGlassDbContext _dbContext;
        public CreateProductCommandHandler(AutoGlassDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Descricao, request.DataFabricacao, request.DataValidade, request.CodigoFornecedor, request.DescricaoFornecedor, request.CNPJFornecedor);

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product.Codigo;
        }
    }
}
