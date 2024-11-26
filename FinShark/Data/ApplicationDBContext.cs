using FinShark.Models;
using Microsoft.EntityFrameworkCore;
using FinShark.Mappers;
namespace FinShark.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comment { get; set; }



    }
}
