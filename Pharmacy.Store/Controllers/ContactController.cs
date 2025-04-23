using Microsoft.AspNetCore.Mvc;

namespace Pharmacy.Store.Controllers
{
    /// <summary>
    /// Контроллер страницы контактов
    /// </summary>
    public class ContactController : Controller
    {
        // GET: /<controller>/
        /// <summary>
        /// Метод-обработчик страницы Index раздела Contact
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
