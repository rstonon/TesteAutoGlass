using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Application.InputModels
{
    public class UpdateProductInputModel
    {
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
