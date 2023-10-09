using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Application.ViewModels
{
    public class ProductViewModel
    {


        public ProductViewModel(int codigo, string descricao, ProductStatusEnum situacao)
        {
            Codigo = codigo;
            Descricao = descricao;
            Situacao = situacao;
        }
        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public ProductStatusEnum Situacao { get; private set; }
    }
}
