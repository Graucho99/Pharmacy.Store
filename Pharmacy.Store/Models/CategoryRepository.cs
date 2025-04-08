namespace Pharmacy.Store.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContext;

        public CategoryRepository(PharmacyStoreDbContext pharmacyStoreDbContext)
        {
            _pharmacyStoreDbContext = pharmacyStoreDbContext;
        }

        public IEnumerable<Category> AllCategories => _pharmacyStoreDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
