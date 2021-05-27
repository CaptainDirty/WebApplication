using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.LoginViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Вы не заполнили поле E-mail.")]
        [EmailAddress(ErrorMessage = "Некорректный E-mail.")]
        public string login { get; set; }

        [Required]
        public string password { get; set; }
    }
}
