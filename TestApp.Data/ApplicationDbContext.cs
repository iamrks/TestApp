using Microsoft.AspNet.Identity.EntityFramework;
using TestApp.Models;
using System.Data.Entity;
using TestApp.Data.Mappers;

namespace TestApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMapper());
            modelBuilder.Configurations.Add(new CategoryMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}
