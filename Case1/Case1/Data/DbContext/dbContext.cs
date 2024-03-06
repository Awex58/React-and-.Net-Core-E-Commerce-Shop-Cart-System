using Case1.Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Case1.Data.DbContext
{
    public class dbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=YOURSERVER;Database=YOURDATABASE; Encrypt=True; Trust Server Certificate=true;Trusted_Connection=False; User Id=YOURID; Password=YOURPASSWORD;");

           

        }
        public DbSet<User> USERS { get; set; }
        public DbSet<Cart> CARTS { get; set; }
        public DbSet<Categories> CATEGORIES { get; set; }
        public DbSet<Product> PRODUCTS { get; set; }
        public DbSet<SalesProducts> SALESPRODUCTS { get; set; }
    }
}
