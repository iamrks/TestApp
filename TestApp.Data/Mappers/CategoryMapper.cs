using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TestApp.Models;

namespace TestApp.Data.Mappers
{
    class CategoryMapper : EntityTypeConfiguration<Category>
    {
        public CategoryMapper()
        {
            this.ToTable("Categories");

            this.Property(c => c.Id).IsRequired();
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.Name).IsRequired();
            this.Property(c => c.Name).HasMaxLength(100);
        }
    }
}
