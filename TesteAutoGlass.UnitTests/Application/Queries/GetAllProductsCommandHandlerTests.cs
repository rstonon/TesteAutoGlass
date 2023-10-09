using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Application.Queries.GetAllProducts;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Core.Repositories;

namespace TesteAutoGlass.UnitTests.Application.Queries
{
    public class GetAllProductsCommandHandlerTests
    {
        //Teste utilizando o padrão Given-When-Then
        [Fact]
        public async Task ProductsExists_Executed_ReturnProductsProjectViewModel()
        {
            var products = new List<Product>
            {
                new Product("Produto 1", new DateTime(2021,10,01), new DateTime(2023,12,30), 1, "Fornecedor 1", "04.048.081/0001-50"),
                new Product("Produto 2", new DateTime(2020,09,11), new DateTime(2023,12,30), 2, "Fornecedor 2", "00.111.222/1234-56"),
                new Product("Produto 3", new DateTime(2022,04,21), new DateTime(2023,12,30), 3, "Fornecedor 3", "99.999.999/9999-99"),
                new Product("Produto 4", new DateTime(2019,08,13), new DateTime(2023,12,30), 2, "Fornecedor 2", "00.111.222/1234-56"),
                new Product("Produto 5", new DateTime(2017,05,17), new DateTime(2023,12,30), 1, "Fornecedor 1", "04.048.081/0001-50"),
            };

            var repositoryMock = new Mock<IProductRepository>();
            repositoryMock.Setup(r => r.GetAllAsync().Result).Returns(products);

            var getAllProductQuery = new GetAllProductsQuery("");
            var getAllProductQueryHandler = new GetAllProductsQueryHandler(repositoryMock.Object);

            var productViewModelList = await getAllProductQueryHandler.Handle(getAllProductQuery, new CancellationToken());

            Assert.NotNull(productViewModelList);
            Assert.NotEmpty(productViewModelList);
            Assert.Equal(products.Count, productViewModelList.Count);

            repositoryMock.Verify(r => r.GetAllAsync().Result, Times.Once);
        }
    }
}
