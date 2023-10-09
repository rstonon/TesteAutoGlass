using Moq;
using TesteAutoGlass.Application.Commands.CreateProduct;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Core.Repositories;

namespace TesteAutoGlass.UnitTests.Application.Commands
{
    public class CreateProductCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProductID()
        {
            var repositoryMock = new Mock<IProductRepository>();

            var createProductCommand = new CreateProductCommand
            {
                Descricao = "PRODUTO Y",
                DataFabricacao = new DateTime(2021,09,21),
                DataValidade = new DateTime(2025,11,19),
                CodigoFornecedor = 1,
                DescricaoFornecedor = "FORNECEDOR Y",
                CNPJFornecedor = "12.345.678/1234-56",
            };

            var createProductCommandHandler = new CreateProductCommandHandler(repositoryMock.Object);

            var id = await createProductCommandHandler.Handle(createProductCommand, new CancellationToken());

            Assert.True(id >= 0);

            repositoryMock.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Once);
        }
    }
}
