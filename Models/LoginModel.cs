using System.ComponentModel.DataAnnotations;

namespace WebApplication_GameCaKoi.Models // Sử dụng không gian tên cho mô hình
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
