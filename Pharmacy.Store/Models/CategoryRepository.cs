namespace Pharmacy.Store.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContext;

        public CategoryRepository(PharmacyStoreDbContext bethanysMedicamentShopDbContext)
        {
            _pharmacyStoreDbContext = bethanysMedicamentShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _pharmacyStoreDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
