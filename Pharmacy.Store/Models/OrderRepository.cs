namespace Pharmacy.Store.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(PharmacyStoreDbContext bethanysMedicamentShopDbContext, IShoppingCart shoppingCart)
        {
            _pharmacyStoreDbContext = bethanysMedicamentShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

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

            _pharmacyStoreDbContext.Orders.Add(order);

            _pharmacyStoreDbContext.SaveChanges();
        }
    }
}
