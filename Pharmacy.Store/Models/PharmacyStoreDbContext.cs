using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Store.Models
{
    public class PharmacyStoreDbContext : DbContext
    {
        public PharmacyStoreDbContext(DbContextOptions<PharmacyStoreDbContext> options)
            : base(options) { }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}