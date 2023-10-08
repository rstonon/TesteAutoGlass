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
        List<ProductViewModel> GetAll(string query);
        ProductDetailsViewModel GetById(int id);
        int Create(NewProductInputModel inputModel);
        void Update(UpdateProductInputModel inputModel);
        void Delete(int id);
    }
}
