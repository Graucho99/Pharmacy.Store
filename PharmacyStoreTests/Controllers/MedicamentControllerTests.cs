using Microsoft.AspNetCore.Mvc;
using PharmacyStoreTests.Mocks;
using Pharmacy.Store.Controllers;
using Pharmacy.Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyStoreTests.Controllers
{
    public class MedicamentControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllPies()
        {
            //arrange
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var mockPieRepository = RepositoryMocks.GetMedicamentRepository();

            var medicamentController = new MedicamentController(mockPieRepository.Object, mockCategoryRepository.Object);

            //act
            var result = medicamentController.List("");

            //assert
            var viewResult = Assert.IsType<ViewResult>((ViewResult)result.Result);
            var medicamentListViewModel = Assert.IsAssignableFrom<MedicamentListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(2, medicamentListViewModel.Medicaments.Count());
        }
    }
}
