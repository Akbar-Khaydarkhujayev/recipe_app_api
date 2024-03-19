using Microsoft.EntityFrameworkCore;
using WAD_CW_13127_API.Models;

namespace WAD_CW_13127_API.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly GeneralDBContext _context;
        public ProductRepository(GeneralDBContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Product categories)
        {
            await _context.Products.AddAsync(categories);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToArrayAsync();
        public async Task<Product> GetByIDAsync(int id) => await _context.Products.FindAsync(id);
        public async Task UpdateAsync(Product categories)
        {
            _context.Entry(categories).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
