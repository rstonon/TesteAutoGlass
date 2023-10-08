namespace TesteAutoGlass.API.Models
{
    public class UpdateProductModel
    {
        public string Descricao { get; set; }
        public int Situacao { get; set; }
        public DateOnly DataFabricacao { get; set; }
        public DateOnly DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }

    }
}
