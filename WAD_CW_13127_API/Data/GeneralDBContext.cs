using Microsoft.EntityFrameworkCore;
using WAD_CW_13127_API.Models;

namespace WAD_CW_13127_API.Data
{
    public class GeneralDBContext : DbContext
    {
        public GeneralDBContext(DbContextOptions<GeneralDBContext> options) : base(options) { }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
