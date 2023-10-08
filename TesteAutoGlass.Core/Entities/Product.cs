using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product(string descricao, DateOnly dataFabricacao, DateOnly dataValidade, int codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            Descricao = descricao;
            Situacao = ProductStatusEnum.Ativo;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
            DescricaoFornecedor = descricaoFornecedor;
            CNPJFornecedor = cnpjFornecedor;
        }
        public string Descricao { get; private set; }
        public ProductStatusEnum Situacao { get; private set; }
        public DateOnly DataFabricacao { get; private set; }
        public DateOnly DataValidade { get; private set; }
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

        public void Update(string descricao, ProductStatusEnum situacao, DateOnly dataFabricacao, DateOnly dataValidade, int codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
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
