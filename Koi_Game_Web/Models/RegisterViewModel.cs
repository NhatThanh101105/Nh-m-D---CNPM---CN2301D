using System.ComponentModel.DataAnnotations;

namespace Koi_Game_Web.Models
{
	public class RegisterViewModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string Name { get; set; } // Thêm thuộc tính Name

        [Required(ErrorMessage = "Bạn phải đồng ý với điều khoản sử dụng.")]
        public bool AcceptTerms { get; set; }
    }
}
