using Pharmacy.Store.Models;
using Pharmacy.Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers
{
    public class MedicamentController : Controller
    {
        private readonly IMedicamentRepository _MedicamentRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MedicamentController(IMedicamentRepository MedicamentRepository, ICategoryRepository categoryRepository)
        {
            _MedicamentRepository = MedicamentRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            MedicamentListViewModel MedicamentsListViewModel = new MedicamentListViewModel(_MedicamentRepository.AllMedicaments, "Каталог");
            return View(MedicamentsListViewModel);
        }
    }
}
