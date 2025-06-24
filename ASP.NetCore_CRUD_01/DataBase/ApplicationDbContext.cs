using ASP.NetCore_CRUD_01.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NetCore_CRUD_01.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        { 
        
        }

        public DbSet<ProductsDetail> PDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductsDetail>().ToTable("Employees");

        }
    }
}
