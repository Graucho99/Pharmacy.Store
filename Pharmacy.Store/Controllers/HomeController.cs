using Pharmacy.Store.Models;
using Pharmacy.Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMedicamentRepository _medicamentRepository;

        public HomeController(IMedicamentRepository medicamentRepository)
        {
            _medicamentRepository = medicamentRepository;
        }

        public ViewResult Index()
        {
            var medicamentsOfTheWeek = _medicamentRepository.DiscountsOfTheWeek;

            var homeViewModel = new HomeViewModel(medicamentsOfTheWeek);

            return View(homeViewModel);
        }
    }
}
