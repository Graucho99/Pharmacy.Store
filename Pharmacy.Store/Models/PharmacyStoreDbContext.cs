using Microsoft.EntityFrameworkCore;
using Pharmacy.Store.Configuration;

namespace Pharmacy.Store.Models
{
    public class PharmacyStoreDbContext:DbContext
    {
        public PharmacyStoreDbContext(DbContextOptions<PharmacyStoreDbContext> options)
            :base(options) { }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Category> Categories { get; set; }    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
