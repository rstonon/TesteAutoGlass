using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Application.InputModels;
using TesteAutoGlass.Application.ViewModels;

namespace TesteAutoGlass.Application.Services.Interfaces
{
    public interface IProductService
    {
        ProductDetailsViewModel GetById(int id);
    }
}
