using Pharmacy.Store.Models;

namespace Pharmacy.Store.ViewModels
{
    /// <summary>
    /// ViewModel админки
    /// </summary>
    public class AdminViewModel
    {
        public Medicament Medicament;
        public IEnumerable<Category> categories;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="categories">Список категорий</param>
        /// <param name="medicament">Модель медикамента</param>
        public AdminViewModel(IEnumerable<Category> categories, Medicament medicament)
        {
            this.categories = categories;
            Medicament = medicament;
        }
    }
}
