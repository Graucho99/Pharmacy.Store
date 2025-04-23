using Pharmacy.Store.Models;
using Pharmacy.Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers
{
    /// <summary>
    /// Контроллер страницы корзины
    /// </summary>
    public class ShoppingCartController : Controller
    {
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly IShoppingCart _shoppingCart;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="medicamentRepository">Объект репозитория медикаментов</param>
        /// <param name="shoppingCart">Объект репозитория корзины</param>
        public ShoppingCartController(IMedicamentRepository medicamentRepository, IShoppingCart shoppingCart)
        {
            _medicamentRepository = medicamentRepository;
            _shoppingCart = shoppingCart;

        }
        /// <summary>
        /// Метод-обработчик страницы Index раздела ShoppingCart
        /// </summary>
        /// <returns></returns>
        public async Task<ViewResult> Index()
        {
            var total = await _shoppingCart.GetShoppingCartTotalAsync();
            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, total);

            return View(shoppingCartViewModel);
        }
        /// <summary>
        /// Метод-обработчик страницы Index раздела ShoppingCart
        /// </summary>
        /// <param name="medicamentId">Идентификатор айтема медикамента</param>
        /// <returns></returns>
        public async Task<RedirectToActionResult> AddToShoppingCart(int medicamentId)
        {
            var medicament = await _medicamentRepository.AllMedicamentsAsync();
            var selectedMedicament = medicament.FirstOrDefault(p => p.MedicamentId == medicamentId);

            if (selectedMedicament != null)
            {
                await _shoppingCart.AddToCartAsync(selectedMedicament);
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Метод-обработчик страницы Index раздела Shopping Cart
        /// </summary>
        /// <param name="medicamentId">Идентификатор айтема медикамента</param>
        /// <returns></returns>
        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int medicamentId)
        {
            var medicament = await _medicamentRepository.AllMedicamentsAsync();
            var selectedMedicament = medicament.FirstOrDefault(p => p.MedicamentId == medicamentId);

            if (selectedMedicament != null)
            {
                await _shoppingCart.RemoveFromCartAsync(selectedMedicament);
            }
            return RedirectToAction("Index");
        }
    }
}
