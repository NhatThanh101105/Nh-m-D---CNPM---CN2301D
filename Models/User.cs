using Microsoft.AspNetCore.Identity;

namespace WebApplication_GameCaKoi.Models // Sử dụng không gian tên cho mô hình
{
    public class User : IdentityUser
    {
        public decimal Balance { get; set; }
    }
}
