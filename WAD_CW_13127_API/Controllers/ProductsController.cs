using Microsoft.AspNetCore.Mvc;
using WAD_CW_13127_API.Models;
using WAD_CW_13127_API.Repositories;

namespace WAD_CW_13127_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        public ProductsController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var resultedProduct = await _repository.GetByIDAsync(id);
            if (resultedProduct == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resultedProduct);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(Product product)
        {
            await _repository.UpdateAsync(product);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _repository.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
