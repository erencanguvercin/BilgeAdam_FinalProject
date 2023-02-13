using System;
using System.ComponentModel.DataAnnotations;

namespace Project.WEB.Models.ViewModels
{
    public class RegisterVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Adress { get; set; }
        [Required(ErrorMessage="Kullanıcı Adı girilmesi zorunldur!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email girilmesi zorunludur!")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Şifre girilmesi zorunludur!")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Şifre Doğrulaması girilmesi zorunludur!")]
        [Compare("Password", ErrorMessage ="Şifreler birbiriyle uyuşmuyor!")]
        public string ConfirmPassword { get; set; }


    }
}
