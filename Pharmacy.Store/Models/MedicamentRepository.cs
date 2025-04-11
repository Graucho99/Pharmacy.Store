using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Store.Models
{
    public class MedicamentRepository : IMedicamentRepository
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContext;

        public MedicamentRepository(PharmacyStoreDbContext bethanysMedicamentShopDbContext)
        {
            _pharmacyStoreDbContext = bethanysMedicamentShopDbContext;
        }

        public IEnumerable<Medicament> AllMedicaments
        {
            get
            {
                return _pharmacyStoreDbContext.Medicaments.Include(c => c.Category);
            }
        }

        public IEnumerable<Medicament> DiscountsOfTheWeek
        {
            get
            {
                return _pharmacyStoreDbContext.Medicaments.Include(c => c.Category).Where(p => p.IsDiscountOfTheWeek);
            }
        }

        public Medicament? GetMedicamentById(int medicamentId)
        {
            return _pharmacyStoreDbContext.Medicaments.FirstOrDefault(p => p.MedicamentId == medicamentId);
        }

        public IEnumerable<Medicament> SearchMedicaments(string searchQuery)
        {
            return _pharmacyStoreDbContext.Medicaments.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
