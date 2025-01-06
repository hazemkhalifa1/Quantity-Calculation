using Microsoft.EntityFrameworkCore;
using QuantityCalculation.API.Models;

namespace QuantityCalculation.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemComponent> ItemComponents { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MB> MBs { get; set; }

    }
}
