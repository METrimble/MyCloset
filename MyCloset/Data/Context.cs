using Microsoft.EntityFrameworkCore;
using MyCloset.Models;

namespace MyCloset.Data
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<ClothingItem> ClothingItems { get; set; }
    }
}
