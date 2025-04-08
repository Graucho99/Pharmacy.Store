using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Store.Models;

namespace Pharmacy.Store.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.CategoryId);

            builder.HasMany(a => a.Medicaments).
                WithOne(a => a.Category);
        }
    }
}
