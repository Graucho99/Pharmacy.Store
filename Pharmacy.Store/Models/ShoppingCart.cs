using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Store.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(PharmacyStoreDbContext bethanysMedicamentShopDbContext)
        {
            _pharmacyStoreDbContext = bethanysMedicamentShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            PharmacyStoreDbContext context = services.GetService<PharmacyStoreDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Medicament medicament)
        {
            var shoppingCartItem =
                    _pharmacyStoreDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Medicament.MedicamentId == medicament.MedicamentId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Medicament = medicament,
                    Amount = 1
                };

                _pharmacyStoreDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _pharmacyStoreDbContext.SaveChanges();
        }

        public int RemoveFromCart(Medicament medicament)
        {
            var shoppingCartItem =
                    _pharmacyStoreDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Medicament.MedicamentId == medicament.MedicamentId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _pharmacyStoreDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _pharmacyStoreDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _pharmacyStoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Medicament)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _pharmacyStoreDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _pharmacyStoreDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _pharmacyStoreDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _pharmacyStoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Medicament.Price * c.Amount).Sum();
            return total;
        }
    }
}
