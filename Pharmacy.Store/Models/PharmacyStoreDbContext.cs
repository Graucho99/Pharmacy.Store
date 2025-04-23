using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Класс DbContext приложения
    /// </summary>
    public class PharmacyStoreDbContext : IdentityDbContext
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="options">Опции, наследующиеся от базового класса DbContext</param>
        public PharmacyStoreDbContext(DbContextOptions<PharmacyStoreDbContext> options)
            : base(options) { }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}