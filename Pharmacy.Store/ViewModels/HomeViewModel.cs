using Microsoft.AspNetCore.Mvc;
using Pharmacy.Store.Models;

namespace Pharmacy.Store.ViewModels
{
    /// <summary>
    /// ViewModel главной страницы
    /// </summary>
    public class HomeViewModel
    {
        public IEnumerable<Medicament> DiscountsOfTheWeek { get; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="discountsOfTheWeek">Медикаменты со скидкой</param>
        public HomeViewModel(IEnumerable<Medicament> discountsOfTheWeek)
        {
            DiscountsOfTheWeek = discountsOfTheWeek;
        }

    }
}
