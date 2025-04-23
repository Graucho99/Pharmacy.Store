namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Интерфейс для репозитория медикаментов
    /// </summary>
    public interface IMedicamentRepository
    {
        Task <IEnumerable<Medicament>> AllMedicamentsAsync();
        Task<IEnumerable<Medicament>> DiscountsOfTheWeekAsync();
        Task<Medicament?> GetMedicamentByIdAsync(int medicamentId);
        Task<IEnumerable<Medicament>> SearchMedicamentsAsync(string searchQuery);

        Task AddItem(Medicament medicament, IEnumerable<Category> category);

        Task UpdateItem(Medicament medicament, IEnumerable<Category> category);
        Task DeleteItem(Medicament medicament);
    }
}
