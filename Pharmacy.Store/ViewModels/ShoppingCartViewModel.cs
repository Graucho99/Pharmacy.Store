using Pharmacy.Store.Models;

namespace Pharmacy.Store.ViewModels
{
    /// <summary>
    /// ViewModel корзины
    /// </summary>
    public class ShoppingCartViewModel
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="shoppingCart">Объект корзины</param>
        /// <param name="shoppingCartTotal">Общая стоимость айтемов корзины</param>
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }

        public IShoppingCart ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
    }
}
