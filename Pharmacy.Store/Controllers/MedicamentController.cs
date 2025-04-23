using Pharmacy.Store.Models;
using Pharmacy.Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers
{
    /// <summary>
    /// Контроллер отображений медикаментов
    /// </summary>
    public class MedicamentController : Controller
    {
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="medicamentRepository">Объект репозитория медикаментов</param>
        /// <param name="categoryRepository">Объект репозитория категории</param>
        public MedicamentController(IMedicamentRepository medicamentRepository, ICategoryRepository categoryRepository)
        {
            _medicamentRepository = medicamentRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Метод-обработчик страницы List раздела Medicament
        /// </summary>
        /// <param name="category">Название категории</param>
        /// <returns></returns>
        public async Task<ViewResult> List(string category)
        {
            IEnumerable<Medicament> medicamentsSelected;
            IEnumerable<Medicament> medicamentsAll;
            string? currentCategory;
            medicamentsAll = await _medicamentRepository.AllMedicamentsAsync();

            if (string.IsNullOrEmpty(category))
            {
                medicamentsSelected = medicamentsAll.OrderBy(p => p.MedicamentId);
                currentCategory = "Все препараты";
            }
            else
            {
                medicamentsSelected = medicamentsAll.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.MedicamentId);
                var categories = await _categoryRepository.AllCategories();
                currentCategory = categories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new MedicamentListViewModel(medicamentsSelected, currentCategory));
        }

        /// <summary>
        /// Метод-обработчик страницы Details раздела Medicament
        /// </summary>
        /// <param name="id">Идентификатор айтема медикамента</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var medicament = await _medicamentRepository.GetMedicamentByIdAsync(id);
            if (medicament == null)
                return NotFound();

            return View(medicament);
        }

        /// <summary>
        /// Метод-обработчик страницы Search раздела Medicament
        /// </summary>
        /// <returns></returns>
        public IActionResult Search()
        {
            return View();
        }
    }
}
