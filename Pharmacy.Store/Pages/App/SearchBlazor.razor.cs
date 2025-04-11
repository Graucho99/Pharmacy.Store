using Pharmacy.Store.Models;
using Microsoft.AspNetCore.Components;

namespace Pharmacy.Store.Pages.App
{
    public partial class SearchBlazor
    {
        public string SearchText = "";
        public List<Medicament> FilteredMedicaments { get; set; } = new List<Medicament>();

        [Inject]
        public IMedicamentRepository? MedicamentRepository { get; set; }

        private void Search()
        {
            FilteredMedicaments.Clear();
            if (MedicamentRepository is not null)
            {
                if (SearchText.Length >= 3)
                    FilteredMedicaments = MedicamentRepository.SearchMedicaments(SearchText).ToList();
            }
        }
    }
}
