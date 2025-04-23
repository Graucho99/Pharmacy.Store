using Pharmacy.Store.Models;

namespace Pharmacy.Store.ViewModels
{
    /// <summary>
    /// ViewModel контроллера отображений медикаментов
    /// </summary>
    public class MedicamentListViewModel
    {
        public IEnumerable<Medicament> Medicaments { get; }
        public string? CurrentCategory { get; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="medicaments">Список препаратов</param>
        /// <param name="currentCategory">Название категории</param>
        public MedicamentListViewModel(IEnumerable<Medicament> medicaments, string? currentCategory)
        {
            Medicaments = medicaments;
            CurrentCategory = currentCategory;
        }
    }
}
