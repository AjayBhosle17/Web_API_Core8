using Microsoft.EntityFrameworkCore;

namespace _01_Web_API_Intro.Models
{
    public class CoreDBContext :DbContext
    {
        public CoreDBContext(DbContextOptions<CoreDBContext> options):base(options) { }
       
        public DbSet<Category> Categories { get; set; }
    }
}
