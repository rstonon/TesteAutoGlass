using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            
        }
        public Product(string descricao, DateTime dataFabricacao, DateTime dataValidade, int codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            Descricao = descricao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
            DescricaoFornecedor = descricaoFornecedor;
            CNPJFornecedor = cnpjFornecedor;

            Situacao = ProductStatusEnum.Ativo;
        }

        public string Descricao { get; private set; }
        public ProductStatusEnum Situacao { get; private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public int CodigoFornecedor { get; private set; }
        public string DescricaoFornecedor { get; private set; }
        public string CNPJFornecedor { get; private set; }

        public void Delete()
        {
            if (Situacao == ProductStatusEnum.Ativo)
            {
                Situacao = ProductStatusEnum.Excluido;
            }
        }

        public void Update(string descricao, ProductStatusEnum situacao, DateTime dataFabricacao, DateTime dataValidade, int codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
            DescricaoFornecedor = descricaoFornecedor;
            CNPJFornecedor = cnpjFornecedor;
        }
    }


}
