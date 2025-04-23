using Pharmacy.Store.Models;
using Pharmacy.Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers
{
    /// <summary>
    /// Контроллер главной страницы
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IMedicamentRepository _medicamentRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="medicamentRepository">Объект репозитория медикаментов</param>
        public HomeController(IMedicamentRepository medicamentRepository)
        {
            _medicamentRepository = medicamentRepository;
        }

        /// <summary>
        /// Метод-обработчик главной страницы
        /// </summary>
        /// <returns></returns>
        public async Task<ViewResult> Index()
        {
            var medicamentsOfTheWeek =  await _medicamentRepository.DiscountsOfTheWeekAsync();

            var homeViewModel = new HomeViewModel(medicamentsOfTheWeek);

            return View(homeViewModel);
        }
    }
}
