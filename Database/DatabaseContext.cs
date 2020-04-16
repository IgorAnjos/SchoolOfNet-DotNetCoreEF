using Microsoft.EntityFrameworkCore;
using SchoolOfNetStudy_DoeNetCoreEF.Models;

namespace SchoolOfNetStudy_DoeNetCoreEF.Database
{
    public class DatabaseContext : DbContext
    {
        
        public DbSet<Product> Products { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }
    }
}