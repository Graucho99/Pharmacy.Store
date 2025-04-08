using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Store.Models;

namespace Pharmacy.Store.Configuration
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(a => a.MedicamentId);

            builder.HasOne(a => a.Category).
                WithMany(c => c.Medicaments);
        }
    }
}
