using Microsoft.EntityFrameworkCore;
using Treinando.Models;

namespace Treinando.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ItemEstoque> Estoque { get; set; }  
    }
}