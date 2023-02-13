using System.ComponentModel.DataAnnotations;

namespace Project.WEB.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı Adı girilmesi zorunludur!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre girilmesi zorunludur!")]
        public string Password { get; set; }
    }
}
