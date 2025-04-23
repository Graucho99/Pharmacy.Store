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

        private async Task SearchAsync()
        {
            var medicament = await MedicamentRepository.SearchMedicamentsAsync(SearchText)
                ?? throw new Exception();
            FilteredMedicaments.Clear();
            if (MedicamentRepository is not null)
            {
                if (SearchText.Length >= 3)
                    FilteredMedicaments = medicament.ToList();
            }
        }
    }
}
