using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteAutoGlass.Application.InputModels;
using TesteAutoGlass.Application.Services.Interfaces;
using TesteAutoGlass.Application.ViewModels;
using TesteAutoGlass.Core.Entities;
using TesteAutoGlass.Infrastructure.Persistence;

namespace TesteAutoGlass.Application.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AutoGlassDbContext _dbContext;
        public ProductService(AutoGlassDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewProductInputModel inputModel)
        {
            var product = new Product(inputModel.Descricao, inputModel.DataFabricacao, inputModel.DataValidade, inputModel.CodigoFornecedor, inputModel.DescricaoFornecedor, inputModel.CNPJFornecedor);

            _dbContext.Products.Add(product);

            return product.Codigo;
        }

        public void Delete(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Codigo == id);

            product.Delete();
        }

        public List<ProductViewModel> GetAll(string query)
        {
            var products = _dbContext.Products;

            var productsViewModel = products
                .Select(p => new ProductViewModel(p.Descricao))
                .ToList();

            return productsViewModel;
        }

        public ProductDetailsViewModel GetById(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Codigo == id);

            if (product == null) return null;

            var productDetailsViewModel = new ProductDetailsViewModel(
                product.Codigo,
                product.Descricao,
                product.Situacao,
                product.DataFabricacao,
                product.DataValidade,
                product.CodigoFornecedor,
                product.DescricaoFornecedor,
                product.CNPJFornecedor
                );

            return productDetailsViewModel;
        }

        public void Update(UpdateProductInputModel inputModel)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Codigo == inputModel.Codigo);

            product.Update(inputModel.Descricao, inputModel.Situacao, inputModel.DataFabricacao, inputModel.DataValidade, inputModel.CodigoFornecedor, inputModel.DescricaoFornecedor, inputModel.CNPJFornecedor);
        }
    }
}
