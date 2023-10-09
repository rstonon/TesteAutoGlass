using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Core.Enums;

namespace TesteAutoGlass.UnitTests.Core.Entities
{
    public class ProductTests
    {
        [Fact]
        public void TestIfProductDeleteWorks()
        {
            var product = new Product(
                "PRODUTO",
                new DateTime(2021,10,09),
                new DateTime(2026,10,10),
                1,
                "FORNECEDOR X",
                "00.000.000/0000-00"
                );

            Assert.NotNull(product.Descricao);
            Assert.NotEmpty(product.Descricao);

            Assert.Equal(ProductStatusEnum.Ativo, product.Situacao);

            product.Delete();

            Assert.Equal(ProductStatusEnum.Inativo, product.Situacao);
            
        }


    }
}
