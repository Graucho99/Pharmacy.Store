namespace Pharmacy.Store.Models
{
    public interface IMedicamentRepository
    {
        IEnumerable<Medicament> AllMedicaments { get; }
        IEnumerable<Medicament> DiscountsOfTheWeek { get; }
        Medicament? GetMedicamentById(int MedicamentId);
        IEnumerable<Medicament> SearchMedicaments(string searchQuery);
    }
}
