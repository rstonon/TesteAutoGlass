using Microsoft.AspNetCore.Mvc;
using TesteAutoGlass.API.Models;
using TesteAutoGlass.Application.InputModels;
using TesteAutoGlass.Application.Services.Interfaces;

namespace TesteAutoGlass.API.Controllers
{
    [Route("api/produtos")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var products = _productService.GetAll(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProductInputModel inputModel)
        {
            if (inputModel.DataFabricacao >= inputModel.DataValidade)
            {
                return BadRequest("Data de Fabricação não pode ser igual ou maior que a data de Validade.");
            }

            var id = _productService.Create(inputModel);

            return CreatedAtAction("GetById", new { id = id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateProductInputModel inputModel)
        {
            if (inputModel.DataFabricacao >= inputModel.DataValidade)
            {
                return BadRequest("Data de Fabricação não pode ser igual ou maior que a data de Validade.");
            }

            _productService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);

            return NoContent();
        }
    }
}
