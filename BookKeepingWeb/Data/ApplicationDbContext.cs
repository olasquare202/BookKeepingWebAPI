using BookKeepingWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookKeepingWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }//add table to the database using DbSet
        public DbSet<Category> Categories { get; set; }
    }
}
