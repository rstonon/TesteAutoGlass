﻿using System;
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
    }
}