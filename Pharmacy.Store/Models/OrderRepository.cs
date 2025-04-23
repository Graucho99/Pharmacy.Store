namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Репозиторий заказа
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContext;
        private readonly IShoppingCart _shoppingCart;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="pharmacyStoreDbContext">Объект DbContext</param>
        /// <param name="shoppingCart">Объект корзины</param>
        public OrderRepository(PharmacyStoreDbContext pharmacyStoreDbContext, IShoppingCart shoppingCart)
        {
            _pharmacyStoreDbContext = pharmacyStoreDbContext;
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Метод, добавляющий заказ в БД
        /// </summary>
        /// <param name="order">Модель заказа</param>
        /// <returns></returns>
        public async Task CreateOrderAsync(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = await _shoppingCart.GetShoppingCartTotalAsync();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    MedicamentId = shoppingCartItem.Medicament.MedicamentId,
                    Price = shoppingCartItem.Medicament.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            await _pharmacyStoreDbContext.Orders.AddAsync(order);

            await _pharmacyStoreDbContext.SaveChangesAsync();
        }
    }
}
