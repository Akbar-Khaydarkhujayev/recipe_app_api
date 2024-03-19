using Microsoft.AspNetCore.Mvc;
using WAD_CW_13127_API.Models;
using WAD_CW_13127_API.Repositories;

namespace WAD_CW_13127_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRepository<Recipe> _repository;
        public RecipesController(IRepository<Recipe> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetRecipes()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var result = await _repository.GetByIDAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutRecipe(Recipe recipe)
        {
            await _repository.UpdateAsync(recipe);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            await _repository.AddAsync(recipe);
            return Ok(recipe);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
