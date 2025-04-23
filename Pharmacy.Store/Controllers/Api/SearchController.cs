using Pharmacy.Store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers.Api
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMedicamentRepository _medicamentRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="medicamentRepository"></param>
        public SearchController(IMedicamentRepository medicamentRepository)
        {
            _medicamentRepository = medicamentRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var allMedicaments = await _medicamentRepository.AllMedicamentsAsync();
            return Ok(allMedicaments);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var allMedicaments = await _medicamentRepository.AllMedicamentsAsync();
            if (!allMedicaments.Any(p => p.MedicamentId == id))
                return NotFound();
            //return new JsonResult(_medicamentRepository.AllMedicaments.Where(p =>p.MedicamentId == id);
            return Ok(allMedicaments.Where(p => p.MedicamentId == id));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task <IActionResult> SearchMedicaments([FromBody] string searchQuery)
        {
            IEnumerable<Medicament> medicaments = new List<Medicament>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                medicaments = await _medicamentRepository.SearchMedicamentsAsync(searchQuery);
            }
            return new JsonResult(medicaments);
        }


    }
}
