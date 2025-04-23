using Microsoft.AspNetCore.Mvc;
using Pharmacy.Store.Controllers;
using Pharmacy.Store.ViewModels;
using PharmacyStoreTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyStoreTests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Use_MedicamentsOfTheWeeks_FromRepository()
        {
            var mockMedicamentRepository = RepositoryMocks.GetMedicamentRepository();

            HomeController homeController = new HomeController(mockMedicamentRepository.Object);

            var result = homeController.Index().Result;


            Assert.NotNull(result);

            var medicamentsOfTheWeek = result.ViewData.Model as HomeViewModel;
            Assert.NotNull(medicamentsOfTheWeek);
            Assert.True(medicamentsOfTheWeek?.DiscountsOfTheWeek?.Count() == 1);
            Assert.Equal("Граммидин Нео с анестетиком таблетки для рассасывания 18 шт", medicamentsOfTheWeek?.DiscountsOfTheWeek.First().Name);


        }
    }
}
