using Microsoft.EntityFrameworkCore;
using WAD_CW_13127_API.Data;
using WAD_CW_13127_API.Models;

namespace WAD_CW_13127_API.Repositories
{
    public class RecipeRepository : IRepository<Recipe>
    {
        private readonly GeneralDBContext _context;

        public RecipeRepository(GeneralDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync() => await _context.Recipes.Include(t => t.Product).ToArrayAsync();

        public async Task<Recipe> GetByIDAsync(int id)
        {
            return await _context.Recipes.Include(t => t.Product).FirstOrDefaultAsync(t => t.ID == id);
        }

        public async Task AddAsync(Recipe entity)
        {
            entity.Product = await _context.Products.FindAsync(entity.ProductID.Value);

            await _context.Recipes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Recipe entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Recipes.FindAsync(id);
            if (entity != null)
            {
                _context.Recipes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
