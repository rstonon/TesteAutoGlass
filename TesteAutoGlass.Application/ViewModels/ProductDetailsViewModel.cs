using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Application.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(int codigo, string descricao, ProductStatusEnum situacao, DateOnly dataFabricacao, DateOnly dataValidade, int codigoFornecedor, string descricaoFornecedor, string cNPJFornecedor)
        {
            Codigo = codigo;
            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
            DescricaoFornecedor = descricaoFornecedor;
            CNPJFornecedor = cNPJFornecedor;
        }

        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public ProductStatusEnum Situacao { get; private set; }
        public DateOnly DataFabricacao { get; private set; }
        public DateOnly DataValidade { get; private set; }
        public int CodigoFornecedor { get; private set; }
        public string DescricaoFornecedor { get; private set; }
        public string CNPJFornecedor { get; private set; }
    }
}
