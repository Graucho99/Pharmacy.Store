using Pharmacy.Store.Models;
using Pharmacy.Store.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers
{
    public class MedicamentController : Controller
    {
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly ICategoryRepository _categoryRepository;

        public MedicamentController(IMedicamentRepository medicamentRepository, ICategoryRepository categoryRepository)
        {
            _medicamentRepository = medicamentRepository;
            _categoryRepository = categoryRepository;
        }

        //public IActionResult List()
        //{
        //    //ViewBag.CurrentCategory = "Cheese cakes";

        //    //return View(_medicamentRepository.AllMedicaments);

        //    MedicamentListViewModel medicamentsListViewModel = new MedicamentListViewModel(_medicamentRepository.AllMedicaments, "Cheese cakes");
        //    return View(medicamentsListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Medicament> medicaments;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                medicaments = _medicamentRepository.AllMedicaments.OrderBy(p => p.MedicamentId);
                currentCategory = "Все препараты";
            }
            else
            {
                medicaments = _medicamentRepository.AllMedicaments.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.MedicamentId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new MedicamentListViewModel(medicaments, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var medicament = _medicamentRepository.GetMedicamentById(id);
            if (medicament == null)
                return NotFound();

            return View(medicament);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
