using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Store.Models
{
    public class MedicamentRepository : IMedicamentRepository
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContextDbContext;

        public MedicamentRepository(PharmacyStoreDbContext pharmacyStoreDbContextDbContext)
        {
            _pharmacyStoreDbContextDbContext = pharmacyStoreDbContextDbContext;
        }

        public IEnumerable<Medicament> AllMedicaments
        {
            get
            {
                return _pharmacyStoreDbContextDbContext.Medicaments.Include(c => c.Category);
            }
        }

        public IEnumerable<Medicament> DiscountsOfTheWeek
        {
            get
            {
                return _pharmacyStoreDbContextDbContext.Medicaments.Include(c => c.Category).Where(p => p.IsDiscountOfTheWeek);
            }
        }

        public Medicament? GetMedicamentById(int MedicamentId)
        {
            return _pharmacyStoreDbContextDbContext.Medicaments.FirstOrDefault(p => p.MedicamentId == MedicamentId);
        }

        public IEnumerable<Medicament> SearchMedicaments(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
