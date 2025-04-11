namespace Pharmacy.Store.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            PharmacyStoreDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<PharmacyStoreDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Medicaments.Any())
            {
                context.AddRange
                (
                    new Medicament { Name = "Эналаприл таблетки 10 мг 20 шт", Price = 52M, ShortDescription = "Действующее вещество: Эналаприл", LongDescription = "Производитель: Озон, Россия\r\n\r\nДействующее вещество: Эналаприл\r\n\r\nСрок годности: Длинный срок", Category = Categories["Сердечно-сосудистые"], ImageUrl = "\\Images\\products\\enalapril.png", InStock = true, IsDiscountOfTheWeek = false, ImageThumbnailUrl = "\\Images\\products\\enalapril.png", AllergyInformation = "" },
                    new Medicament { Name = "Граммидин Нео с анестетиком таблетки для рассасывания 18 шт", Price = 589M, ShortDescription = "Производитель: Валента Фарм АО, Россия\r\n\r\nДействующее вещество: Грамицидин С, Оксибупрокаин, Цитилпиридиния хлорид\r\n\r\nСрок годности: Длинный срок", Category = Categories["Ухо, горло, нос"], ImageUrl = "wwwroot\\Images\\products\\grammidin.png", InStock = true, IsDiscountOfTheWeek = true, ImageThumbnailUrl = "wwwroot\\Images\\products\\grammidin.png", AllergyInformation = "" },
                    new Medicament { Name = "Стрепсилс Интенсив спрей для местного применения дозированный 8,75 мг/доза 15 мл 1 шт", Price = 459M, ShortDescription = "Действующее вещество: Флурбипрофен", LongDescription = "Производитель: Рекитт Бенкизер Хелскэр Мануфэкчуринг (Таиланд), Таиланд\r\n\r\nДействующее вещество: Флурбипрофен\r\n\r\nСрок годности: Длинный срок", Category = Categories["Ухо, горло, нос"], ImageUrl = "wwwroot\\Images\\products\\strepsils.png", InStock = true, IsDiscountOfTheWeek = true, ImageThumbnailUrl = "wwwroot\\Images\\products\\strepsils.png", AllergyInformation = "" },
                    new Medicament { Name = "Амоксициллин Диспертаб таблетки диспергируемые 250 мг 20 шт", Price = 274M, ShortDescription = "Действующее вещество: Амоксициллин", LongDescription = "Производитель: АВВА РУС, Россия\r\n\r\nДействующее вещество: Амоксициллин\r\n\r\nСрок годности: Длинный срок", Category = Categories["Антибиотики"], ImageUrl = "wwwroot\\Images\\products\\amox.png", InStock = true, IsDiscountOfTheWeek = false, ImageThumbnailUrl = "wwwroot\\Images\\products\\amox.png", AllergyInformation = "" },
                    new Medicament { Name = "Азитромицин-Вертекс капсулы 250 мг 6 шт", Price = 199M, ShortDescription = "Действующее вещество: Азитромицин", LongDescription = "Производитель: Вертекс, Россия\r\n\r\nДействующее вещество: Азитромицин\r\n\r\nСрок годности: Длинный срок", Category = Categories["Антибиотики"], ImageUrl = "wwwroot\\Images\\products\\vertex.png", InStock = true, IsDiscountOfTheWeek = false, ImageThumbnailUrl = "wwwroot\\Images\\products\\vertex.png", AllergyInformation = "" }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Ухо, горло, нос" },
                        new Category { CategoryName = "Антибиотики" },
                        new Category { CategoryName = "Сердечно-сосудистые" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
