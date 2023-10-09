using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Application.ViewModels;
using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.Application.Queries.GetByIDProduct
{
    public class GetByIDProductQuery : IRequest<ProductDetailsViewModel>
    {
        public GetByIDProductQuery(int codigo)
        {
            Codigo = codigo;
        }

        public int Codigo { get; private set; }
    }
}
