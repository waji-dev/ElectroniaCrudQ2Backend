using ElectroniaCrudQ2Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElectroniaCrudQ2Backend.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
