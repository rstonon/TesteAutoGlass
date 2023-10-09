using MediatR;
using TesteAutoGlass.Core.Repositories;

namespace TesteAutoGlass.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Codigo);

            product.Update(request.Descricao, request.Situacao, request.DataFabricacao, request.DataValidade, request.CodigoFornecedor, request.DescricaoFornecedor, request.CNPJFornecedor);

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
