using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ver2.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введіть ім'я")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина ім'я не менше 5 символів")]
        public string name { get; set; }
        [Display(Name = "Введіть прізвище")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина прізвища не менше 5 символів")]
        public string surname { get; set; }
        [Display(Name = "Введіть адресу")]
        [StringLength(35)]
        [Required(ErrorMessage = "Довжина адреси не менше 15 символів")]
        public string address { get; set; }
        [Display(Name = "Введіть номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Довжина номера не менше 10 символів")]
        public string phone { get; set; }
        [Display(Name = "Введіть пошту")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Довжина email не менше 15 символів")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)] //поле не відображається в коді
        public DateTime orderTime { get; set; }
        [BindNever]
        public List<OrderDetail> orgerDetails { get; set; }
    }


}
