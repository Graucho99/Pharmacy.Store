using Pharmacy.Store.Models;

namespace Pharmacy.Store.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Medicament> MedicamentsOfTheWeek { get; }

        public HomeViewModel(IEnumerable<Medicament> medicamentsOfTheWeek)
        {
            MedicamentsOfTheWeek = medicamentsOfTheWeek;
        }
    }
}
