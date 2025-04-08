using Pharmacy.Store.Models;

namespace Pharmacy.Store.ViewModels
{
    public class MedicamentListViewModel
    {
        public IEnumerable<Medicament> Medicaments { get; }
        public string? CurrentCategory { get; }

        public MedicamentListViewModel(IEnumerable<Medicament> medicaments, string? currentCategory)
        {
            Medicaments = medicaments;
            CurrentCategory = currentCategory;
        }
    }
}
