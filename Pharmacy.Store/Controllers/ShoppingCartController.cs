using Pharmacy.Store.Models;
using Pharmacy.Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IMedicamentRepository medicamentRepository, IShoppingCart shoppingCart)
        {
            _medicamentRepository = medicamentRepository;
            _shoppingCart = shoppingCart;

        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int medicamentId)
        {
            var selectedMedicament = _medicamentRepository.AllMedicaments.FirstOrDefault(p => p.MedicamentId == medicamentId);

            if (selectedMedicament != null)
            {
                _shoppingCart.AddToCart(selectedMedicament);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int medicamentId)
        {
            var selectedMedicament = _medicamentRepository.AllMedicaments.FirstOrDefault(p => p.MedicamentId == medicamentId);

            if (selectedMedicament != null)
            {
                _shoppingCart.RemoveFromCart(selectedMedicament);
            }
            return RedirectToAction("Index");
        }
    }
}
