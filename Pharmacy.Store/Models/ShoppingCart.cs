using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Репозиторий корзины
    /// </summary>
    public class ShoppingCart : IShoppingCart
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="pharmacyStoreDbContext">Объект DbContext</param>
        private ShoppingCart(PharmacyStoreDbContext pharmacyStoreDbContext)
        {
            _pharmacyStoreDbContext = pharmacyStoreDbContext;
        }

        /// <summary>
        /// Метод, создающий корзину
        /// </summary>
        /// <param name="services">Объект IServiceProvider</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            PharmacyStoreDbContext context = services.GetService<PharmacyStoreDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        /// <summary>
        /// Метод добавления айтема в корзину
        /// </summary>
        /// <param name="medicament">Модель медикамента</param>
        /// <returns></returns>
        public async Task AddToCartAsync(Medicament medicament)
        {
            var shoppingCartItem =
                   await _pharmacyStoreDbContext.ShoppingCartItems.SingleOrDefaultAsync(
                        s => s.Medicament.MedicamentId == medicament.MedicamentId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Medicament = medicament,
                    Amount = 1
                };

                await _pharmacyStoreDbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            await _pharmacyStoreDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод удаления айтема из корзины
        /// </summary>
        /// <param name="medicament">Модель медикамента</param>
        /// <returns></returns>
        public async Task<int> RemoveFromCartAsync(Medicament medicament)
        {
            var shoppingCartItem =
                    await _pharmacyStoreDbContext.ShoppingCartItems.SingleOrDefaultAsync(
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

            await _pharmacyStoreDbContext.SaveChangesAsync();

            return localAmount;
        }

        /// <summary>
        /// Метод получения айтемов в корзине
        /// </summary>
        /// <returns></returns>
        public async Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync()
        {
            return ShoppingCartItems ??=
                       await _pharmacyStoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Medicament)
                           .ToListAsync();
        }

        /// <summary>
        /// Метод очистки корзины
        /// </summary>
        /// <returns></returns>
        public async Task ClearCartAsync()
        {
            var cartItems = await _pharmacyStoreDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId).ToListAsync();

            _pharmacyStoreDbContext.ShoppingCartItems.RemoveRange(cartItems);

            await _pharmacyStoreDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод подсчета общей стоимости препаратов
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetShoppingCartTotalAsync()
        {
            var shoppingCartItems = await _pharmacyStoreDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Select(c => c.Medicament.Price * c.Amount).ToListAsync();
            var total =  shoppingCartItems.Sum();
           
            return total;
        }
    }
}
