using MediatR;
using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Application.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}
