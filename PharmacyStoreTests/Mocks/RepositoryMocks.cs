using Moq;
using Pharmacy.Store.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyStoreTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IMedicamentRepository> GetMedicamentRepository()
        {
            var medicaments = new List<Medicament>
            {
                new Medicament
                {
                    Name = "Граммидин Нео с анестетиком таблетки для рассасывания 18 шт",
                    Price = 126.00M,
                    ShortDescription = "Действующее вещество: Грамицидин С, Оксибупрокаин, Цитилпиридиния хлорид",
                    LongDescription =
                        "Производитель: Валента Фарм АО, Россия Действующее вещество: Грамицидин С, Оксибупрокаин, Цитилпиридиния хлорид Срок годности: Длинный срок",
                    ImageUrl = "wwwroot\\Images\\products\\grammidin.png",
                    InStock = true,
                    IsDiscountOfTheWeek = true,
                    ImageThumbnailUrl = "wwwroot\\Images\\products\\grammidin.png",
                    AllergyInformation = ""
                },
                new Medicament
                {
                    Name = "Амоксициллин Диспертаб таблетки диспергируемые 250 мг 20 шт",
                    Price = 187.00M,
                    ShortDescription = "Действующее вещество: Амоксициллин",
                    LongDescription =
                        "Производитель: АВВА РУС, Россия\r\n\r\nДействующее вещество: Амоксициллин\r\n\r\nСрок годности: Длинный срок",
                    Category = Categories["Антибиотики"],
                    ImageUrl = "\\Images\\products\\amox.png",
                    InStock = true,
                    IsDiscountOfTheWeek = false,
                    ImageThumbnailUrl =
                        "\\Images\\products\\amox.png",
                    AllergyInformation = ""
                }
                
            };

            var mockMedicamentRepository = new Mock<IMedicamentRepository>();
            mockMedicamentRepository.Setup(repo => repo.AllMedicamentsAsync()).ReturnsAsync(medicaments);
            mockMedicamentRepository.Setup(repo => repo.DiscountsOfTheWeekAsync()).ReturnsAsync(medicaments.Where(p => p.IsDiscountOfTheWeek));
            mockMedicamentRepository.Setup(repo => repo.GetMedicamentByIdAsync(It.IsAny<int>())).ReturnsAsync(medicaments[0]);
            return mockMedicamentRepository;
        }

        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Ухо, горло, нос",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Антибиотики",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Сердечно-сосудистые",
                    Description = "Lorem Ipsum"
                }
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.AllCategories()).ReturnsAsync(categories);

            return mockCategoryRepository;
        }

        private static Dictionary<string, Category>? _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Ухо, горло, нос" },
                        new Category { CategoryName = "Антибиотики" },
                        new Category { CategoryName = "Сердечно-сосудистые" }
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (var genre in genresList)
                    {
                        _categories.Add(genre.CategoryName, genre);
                    }
                }

                return _categories;
            }
        }
    }
}

