using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteAutoGlass.API.Models;
using TesteAutoGlass.Application.Commands.CreateProduct;
using TesteAutoGlass.Application.Commands.DeleteProduct;
using TesteAutoGlass.Application.Commands.UpdateProduct;
using TesteAutoGlass.Application.InputModels;
using TesteAutoGlass.Application.Queries.GetAllProducts;
using TesteAutoGlass.Application.Queries.GetByIDProduct;
using TesteAutoGlass.Application.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TesteAutoGlass.API.Controllers
{
    [Route("api/produtos")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;
        public ProductsController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProductsQuery = new GetAllProductsQuery(query);

            var products = await _mediator.Send(getAllProductsQuery);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getProductByIdQuery = new GetByIDProductQuery(id);

            var product = await _mediator.Send(getProductByIdQuery);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            if (command.DataFabricacao >= command.DataValidade)
            {
                return BadRequest("Data de Fabricação não pode ser igual ou maior que a data de Validade.");
            }

            //var id = _productService.Create(inputModel);

            var id = await _mediator.Send(command);

            return CreatedAtAction("GetById", new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommand command)
        {
            if (command.DataFabricacao >= command.DataValidade)
            {
                return BadRequest("Data de Fabricação não pode ser igual ou maior que a data de Validade.");
            }

            //_productService.Update(inputModel);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
