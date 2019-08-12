using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TestApp.Models;

namespace TestApp.Data.Mappers
{
    class ProductMapper : EntityTypeConfiguration<Product>
    {
        public ProductMapper()
        {
            this.ToTable("Products");
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.Id).IsRequired();

            this.Property(c => c.Name).IsRequired();
            this.Property(c => c.Name).HasMaxLength(100);

            this.Property(c => c.CategoryId).IsRequired();

            this.Property(c => c.UnitPrice).IsRequired();

            this.Property(c => c.ImageUrl).IsOptional();
        }
    }
}
