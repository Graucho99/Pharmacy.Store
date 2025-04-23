using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Модель медикамента
    /// </summary>
    public class Medicament
    {
        [HiddenInput]
        public int MedicamentId { get; set; }

        [Required(ErrorMessage = "Введите название товара")]
        [Display(Name = "Название")]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите краткое описание")]
        [Display(Name = "Краткое описание")]
        [StringLength(300)]
        public string? ShortDescription { get; set; }

        [Required(ErrorMessage = "Введите полное описание")]
        [Display(Name = "Полное описание")]
        
        public string? LongDescription { get; set; }

        [Display(Name = "Информация об аллергенах")]
        [StringLength(200)]
        public string? AllergyInformation { get; set; }

        [Required(ErrorMessage = "Введите стоимость товара")]
        [Display(Name = "Цена")]
        [RegularExpression("([0-9]+)", ErrorMessage ="Должно быть числом")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Введите адрес ссылки на изображение товара")]
        [Display(Name = "Изображение товара")]
        [StringLength(300)]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "Введите адрес ссылки на миниатюру изображения товара")]
        [Display(Name = "Ссылка на миниатюру изображения товара")]
        [StringLength(300)]
        public string? ImageThumbnailUrl { get; set; }

        [Display(Name = "Скидка недели")]
        public bool IsDiscountOfTheWeek { get; set; }

        [Display(Name = "В наличии")]
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

    }
}
