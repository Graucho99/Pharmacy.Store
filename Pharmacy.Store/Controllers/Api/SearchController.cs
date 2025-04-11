using Pharmacy.Store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMedicamentRepository _medicamentRepository;

        public SearchController(IMedicamentRepository medicamentRepository)
        {
            _medicamentRepository = medicamentRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var allMedicaments = _medicamentRepository.AllMedicaments;
            return Ok(allMedicaments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_medicamentRepository.AllMedicaments.Any(p => p.MedicamentId == id))
                return NotFound();
            //return new JsonResult(_medicamentRepository.AllMedicaments.Where(p =>p.MedicamentId == id);
            return Ok(_medicamentRepository.AllMedicaments.Where(p => p.MedicamentId == id));
        }

        [HttpPost]
        public IActionResult SearchMedicaments([FromBody] string searchQuery)
        {
            IEnumerable<Medicament> medicaments = new List<Medicament>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                medicaments = _medicamentRepository.SearchMedicaments(searchQuery);
            }
            return new JsonResult(medicaments);
        }


    }
}
