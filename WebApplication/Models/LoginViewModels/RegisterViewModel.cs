using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.LoginViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Вы не заполнили поле E-mail.")]
        [EmailAddress(ErrorMessage = "Некорректный e-mail.")]
        public string login { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Минимальная длина пароля 5 символов.")]
        public string password { get; set; }
    }
}
