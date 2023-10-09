using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Infrastructure.Persistence;

namespace TesteAutoGlass.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly AutoGlassDbContext _dbContext;
        public UpdateProductCommandHandler(AutoGlassDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Codigo == request.Codigo);

            product.Update(request.Descricao, request.Situacao, request.DataFabricacao, request.DataValidade, request.CodigoFornecedor, request.DescricaoFornecedor, request.CNPJFornecedor);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
