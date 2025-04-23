using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Store.Models
{
    /// <summary>
    /// Модель заказа
    /// </summary>
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите свое имя")]
        [Display(Name = "Имя")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пожалуйста введите свою фамилию")]
        [Display(Name = "Фамилия")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пожалуйста введите свой адрес")]
        [StringLength(100)]
        [Display(Name = "Адрес 1")]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name = "Адрес 2")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите свой индекс")]
        [Display(Name = "Индекс")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пожалуйста введите свой город")]
        [StringLength(50)]
        [Display(Name = "Город")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пожалуйста введите свою область")]
        [StringLength(10)]
        [Display(Name = "Область")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите свою страну")]
        [StringLength(50)]
        [Display(Name = "Страна")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пожалуйста введите свой телефонный номер")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пожалуйста введите свою электронную почту")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Электронная почта")]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Электронная почта в неккоректном формате")]
        public string Email { get; set; } = string.Empty;

        [BindNever]
        public decimal OrderTotal { get; set; }

        [BindNever]
        public DateTime OrderPlaced { get; set; }
    }
}
