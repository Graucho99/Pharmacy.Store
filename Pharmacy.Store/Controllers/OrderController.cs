using Pharmacy.Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers
{
    /// <summary>
    /// Контроллер страницы заказа
    /// </summary>
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="orderRepository">Объект репозитория заказа</param>
        /// <param name="shoppingCart">Объект репозитория корзины</param>
        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Метод-обработчик страницы Checkout раздела Order
        /// </summary>
        /// <returns></returns>
        public IActionResult Checkout()
        {
            return View();
        }

        /// <summary>
        /// Метод-обработчик страницы Checkout раздела Order
        /// </summary>
        /// <param name="order">Модель заказа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Ваша корзина пуста, добавьте товары");
            }

            if (ModelState.IsValid)
            {
                await _orderRepository.CreateOrderAsync(order);
                await _shoppingCart.ClearCartAsync();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        /// <summary>
        /// Метод-обработчик страницы CheckoutComplete раздела Order
        /// </summary>
        /// <returns></returns>
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Спасибо за заказ!";
            return View();
        }
    }
}
