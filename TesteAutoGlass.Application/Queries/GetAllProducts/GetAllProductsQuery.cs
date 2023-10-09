using MediatR;
using TesteAutoGlass.Application.ViewModels;
using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Application.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductViewModel>>
    {
        public GetAllProductsQuery(string descricao, ProductStatusEnum situacao, int pagina, int registrosPorPagina)
        {
            Descricao = descricao;
            Situacao = situacao;
            Pagina = pagina;
            QntRegistrosPorPagina = registrosPorPagina;
        }
        public string Descricao { get; private set; }
        public ProductStatusEnum Situacao { get; private set; }
        public int Pagina { get; private set; }
        public int QntRegistrosPorPagina { get; private set; }
    }
}
