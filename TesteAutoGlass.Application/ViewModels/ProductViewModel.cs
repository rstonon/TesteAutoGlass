using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAutoGlass.Application.ViewModels
{
    public class ProductViewModel
    {


        public ProductViewModel(string descricao)
        {
            Descricao = descricao;
        }
        public string Descricao { get; private set; }
    }
}
