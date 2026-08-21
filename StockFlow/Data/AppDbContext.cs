using Microsoft.EntityFrameworkCore;
using StockFlow.Models;

namespace StockFlow.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }
}
