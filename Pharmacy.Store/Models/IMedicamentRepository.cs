namespace Pharmacy.Store.Models
{
    public interface IMedicamentRepository
    {
        IEnumerable<Medicament> AllMedicaments { get; }
        IEnumerable<Medicament> DiscountsOfTheWeek { get; }
        Medicament? GetMedicamentById(int medicamentId);
        IEnumerable<Medicament> SearchMedicaments(string searchQuery);
    }
}
