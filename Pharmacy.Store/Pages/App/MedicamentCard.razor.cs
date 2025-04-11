using Pharmacy.Store.Models;
using Microsoft.AspNetCore.Components;

namespace Pharmacy.Store.Pages.App
{
    public partial class MedicamentCard
    {
        [Parameter]
        public Medicament? Medicament { get; set; }
    }
}
