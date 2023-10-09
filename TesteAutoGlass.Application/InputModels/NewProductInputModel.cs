using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Application.InputModels
{
    public class NewProductInputModel
    {
        public string Descricao { get; set; }
        public ProductStatusEnum Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}
