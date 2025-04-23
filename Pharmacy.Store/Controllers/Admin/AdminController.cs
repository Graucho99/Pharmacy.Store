using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Store.Models;
using Pharmacy.Store.ViewModels;

namespace Pharmacy.Store.Controllers.Admin
{
    /// <summary>
    /// Контроллер админки
    /// </summary>
    [Authorize(Roles="admin")]
    public class AdminController : Controller
    {
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="medicamentRepository">Объект репозитория медикаментов</param>
        /// <param name="categoryRepository">Объект репозитория категории</param>
        public AdminController(IMedicamentRepository medicamentRepository, ICategoryRepository categoryRepository)
        {
            _medicamentRepository = medicamentRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Метод-обработчик страницы Index раздела Admin
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var medicamentList = await _medicamentRepository.AllMedicamentsAsync();
            var itemManagerViewModel = new MedicamentListViewModel(medicamentList, null);
            return View(itemManagerViewModel);
        }

        /// <summary>
        /// Метод-обработчик страницы AddItem раздела Admin
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AddItem()
        {
            var medicament = new Medicament();
            var categories = await _categoryRepository.AllCategories();
            var adminViewModel = new AdminViewModel(categories, medicament);
            return View(adminViewModel);
        }

        /// <summary>
        /// Метод-обработчик страницы EditItem раздела Admin
        /// </summary>
        /// <param name="id">Идентификатор айтема медикамента</param>
        /// <returns></returns>
        public async Task<IActionResult> EditItem(int id)
        {
            var medicament = await _medicamentRepository.GetMedicamentByIdAsync(id);
            if (medicament == null)
                return NotFound();
            var categories = await _categoryRepository.AllCategories();
            var adminViewModel = new AdminViewModel(categories, medicament);    
            return View(adminViewModel);
        }
        /// <summary>
        /// Метод добавления нового айтема в БД
        /// </summary>
        /// <param name="medicament">Модель айтема медикамента</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Medicament medicament)
        {
            if (ModelState.IsValid)
            {
                var categories = await _categoryRepository.AllCategories();
                await _medicamentRepository.AddItem(medicament, categories);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index"); //(medicament)
        }

        /// <summary>
        /// Метод-апдейт существующего айтема в БД
        /// </summary>
        /// <param name="medicament">Модель айтема медикамента</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(Medicament medicament)
        {
            if (ModelState.IsValid)
            {
                var categories = await _categoryRepository.AllCategories();
                await _medicamentRepository.UpdateItem(medicament, categories);
                return RedirectToAction("Index");
            }
            
            //return View(medicament); //(medicament)
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Метод-удаление айтема из БД
        /// </summary>
        /// <param name="id">Идентификатор айтема медикамента</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<RedirectToActionResult> Delete(int id)
        {
            var medicament =  await _medicamentRepository.GetMedicamentByIdAsync(id)
                ?? throw new Exception();
            await _medicamentRepository.DeleteItem(medicament);
            return RedirectToAction("Index");
        }
    }
}
