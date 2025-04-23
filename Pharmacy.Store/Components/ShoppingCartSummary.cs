using Pharmacy.Store.Models;
using Pharmacy.Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Components
{
    /// <summary>
    /// Класс-компонент для счетчика айтемов в корзине
    /// </summary>
    public class ShoppingCartSummary: ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="shoppingCart">Объект корзины</param>
        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Метод-обработчик, возвращающий количество айтемов и общую стоимость
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem() };
            var total = await _shoppingCart.GetShoppingCartTotalAsync();
            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, total);

            return View(shoppingCartViewModel);
        }
    }
}
