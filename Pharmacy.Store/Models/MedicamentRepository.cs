using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Репозиторий медикаментов
    /// </summary>
    public class MedicamentRepository : IMedicamentRepository
    {
        private readonly PharmacyStoreDbContext _pharmacyStoreDbContext;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="pharmacyStoreDbContext">Объект DBcontext</param>
        public MedicamentRepository(PharmacyStoreDbContext pharmacyStoreDbContext)
        {
            _pharmacyStoreDbContext = pharmacyStoreDbContext;
        }

        /// <summary>
        /// Метод, возвращающий все медикаменты
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Medicament>> AllMedicamentsAsync()
        {
            var allMedicaments = await _pharmacyStoreDbContext.Medicaments.Include(c => c.Category).ToListAsync();   
            return allMedicaments;
        }

        /// <summary>
        /// Метод, возвращающий позиции медикаментов со скидкой
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Medicament>> DiscountsOfTheWeekAsync()
        {
            var discountOfTheWeek = await _pharmacyStoreDbContext.Medicaments.Include(c => c.Category).Where(p => p.IsDiscountOfTheWeek).ToListAsync();
            return discountOfTheWeek;
        }

        /// <summary>
        /// Метод, возвращающий определенный препарат
        /// </summary>
        /// <param name="medicamentId">Идентификатор айтема медикамента</param>
        /// <returns></returns>
        public async Task<Medicament?> GetMedicamentByIdAsync(int medicamentId)
        {
            var medicament = await _pharmacyStoreDbContext.Medicaments.FirstOrDefaultAsync(p => p.MedicamentId == medicamentId);
            return medicament;
        }

        /// <summary>
        /// Метод поиска медикамента (-ов)
        /// </summary>
        /// <param name="searchQuery">Строка поискового запроса</param>
        /// <returns></returns>
        public async Task<IEnumerable<Medicament>> SearchMedicamentsAsync(string searchQuery)
        {
            var medicamentsList = await _pharmacyStoreDbContext.Medicaments.Where(p => p.Name.Contains(searchQuery)).ToListAsync();
            return medicamentsList;
        }

        /// <summary>
        /// Метод добавления нового медикамента в БД
        /// </summary>
        /// <param name="medicament">Модель медикамента</param>
        /// <param name="categories">Список категорий для сопоставления с данными из модели медикамента</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task AddItem(Medicament medicament, IEnumerable<Category> categories)
        {  
            var categoryEntity = categories.
               FirstOrDefault(c => c.CategoryName == medicament.Category.CategoryName)
               ?? throw new Exception();
            
            var medicamentEntity = new Medicament
            {
                Name = medicament.Name,
                ShortDescription = medicament.ShortDescription,
                LongDescription = medicament.LongDescription,
                Price = medicament.Price,
                ImageThumbnailUrl = medicament.ImageThumbnailUrl,
                ImageUrl = medicament.ImageUrl,
                AllergyInformation = medicament.AllergyInformation,
                InStock = medicament.InStock,   
                IsDiscountOfTheWeek = medicament.IsDiscountOfTheWeek,
                CategoryId = categoryEntity.CategoryId,
            };  
            await _pharmacyStoreDbContext.AddAsync(medicamentEntity);
            await _pharmacyStoreDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Метод-апдейт существующего медикамента в БД
        /// </summary>
        /// <param name="medicament">Модель медикамента</param>
        /// <param name="categories">Список категорий для сопоставления с данными из модели медикамента</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateItem(Medicament medicament, IEnumerable<Category> categories)
        {
            var medicamentEntity = await _pharmacyStoreDbContext.Medicaments.
                FirstOrDefaultAsync(c => c.MedicamentId == medicament.MedicamentId)
                ?? throw new Exception();
            var categoryEntity = categories.
                FirstOrDefault(c => c.CategoryName == medicament.Category.CategoryName)
                ?? throw new Exception();
            medicamentEntity.Name = medicament.Name;
            medicamentEntity.Price = medicament.Price;
            medicamentEntity.ShortDescription = medicament.ShortDescription;
            medicamentEntity.LongDescription = medicament.LongDescription;
            medicamentEntity.CategoryId = categoryEntity.CategoryId;
            medicamentEntity.AllergyInformation = medicament.AllergyInformation;    
            medicamentEntity.ImageThumbnailUrl = medicament.ImageThumbnailUrl;
            medicamentEntity.ImageUrl = medicament.ImageUrl;
            medicamentEntity.InStock = medicament.InStock;
            medicamentEntity.IsDiscountOfTheWeek = medicament.IsDiscountOfTheWeek;

            await _pharmacyStoreDbContext.SaveChangesAsync();

        }

        /// <summary>
        /// Метод удаления медикамента из БД
        /// </summary>
        /// <param name="medicament">Модель медикамента</param>
        /// <returns></returns>
        public async Task DeleteItem(Medicament medicament)
        {
             _pharmacyStoreDbContext.Medicaments.Remove(medicament);
        
            await _pharmacyStoreDbContext.SaveChangesAsync();


        }
    }
}
