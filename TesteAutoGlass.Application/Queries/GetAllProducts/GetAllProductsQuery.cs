using MediatR;
using TesteAutoGlass.Application.ViewModels;
using TesteAutoGlass.Core.Models;

namespace TesteAutoGlass.Application.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<PaginationResult<ProductViewModel>>
    {
        public string Descricao { get; set; }
        public int Page { get; set; } = 1;
    }
}
