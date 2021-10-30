using System.ComponentModel.DataAnnotations;

namespace TaskManagement.UI.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Parola boş geçilemez.")]
        public string Password { get; set; }
    }
}
