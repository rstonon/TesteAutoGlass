using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutoGlass.Application.ViewModels
{
    public class ProductViewModel
    {


        public ProductViewModel(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
    }
}
