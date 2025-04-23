using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Класс-репозиторий для категорий товаров
    /// </summary>
    public class CategoryRepository: ICategoryRepository
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContext;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="pharmacyStoreDbContext"></param>
        public CategoryRepository(PharmacyStoreDbContext pharmacyStoreDbContext)
        {
            _pharmacyStoreDbContext = pharmacyStoreDbContext;
        }
        /// <summary>
        /// Метод, возвращающий лист со всеми категориями
        /// </summary>
        /// <returns>allCategories</returns>
        public async Task<IEnumerable<Category>> AllCategories()
        {
            var allCategories = await _pharmacyStoreDbContext.Categories.OrderBy(p => p.CategoryName).ToListAsync();
            return allCategories;   

        }
    }
}
