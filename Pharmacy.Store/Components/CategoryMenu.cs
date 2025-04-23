using Pharmacy.Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Components
{
    /// <summary>
    /// Класс-компонент для выпадающего меню категорий на главной странице
    /// </summary>
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="categoryRepository">Объект категории</param>
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Метод-обработчик, представляющий выборку с категориями
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesSelected = await _categoryRepository.AllCategories();
            var categories = categoriesSelected.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
