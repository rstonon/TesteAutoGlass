using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Infrastructure.Persistence;

namespace TesteAutoGlass.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly AutoGlassDbContext _dbContext;
        public DeleteProductCommandHandler(AutoGlassDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Codigo == request.Codigo);

            product.Delete();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
