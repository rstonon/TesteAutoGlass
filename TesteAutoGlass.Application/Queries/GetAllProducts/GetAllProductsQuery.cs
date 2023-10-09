using MediatR;
using TesteAutoGlass.Application.ViewModels;

namespace TesteAutoGlass.Application.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductViewModel>>
    {
        public GetAllProductsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
