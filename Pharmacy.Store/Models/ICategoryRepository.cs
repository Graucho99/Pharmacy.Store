namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Интерфейс для репозитория категорий товаров
    /// </summary>
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> AllCategories();
    }
}
