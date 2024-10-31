using Koi_Game_Reposities.Interfaces; // Thêm các không gian tên cần thiết
using Koi_Game_Services.Interfaces;
using Koi_Game_Services.Class;
using Koi_Game_Reposities.Class;
using Microsoft.EntityFrameworkCore;
using Koi_Game_Reposities.Entities;

var builder = WebApplication.CreateBuilder(args); // Tạo builder cho ứng dụng

// Đăng ký DbContext
builder.Services.AddDbContext<KoiDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql"))); // Thay "YourConnectionStringName" bằng tên connection string của bạn trong appsettings.json

// Đăng ký các dịch vụ cần thiết cho ứng dụng
builder.Services.AddControllersWithViews();

// Đăng ký các dịch vụ của bạn
builder.Services.AddScoped<IPlayerService, PlayerService>(); // Thêm PlayerService
builder.Services.AddScoped<INapTienService, NapTienService>(); // Thêm NapTienService
builder.Services.AddScoped<ILoginService, LoginService>(); // Đăng ký ILoginService

// Thêm các repository
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>(); // Thay thế với tên repository của bạn
// Thêm các repository khác nếu có

var app = builder.Build(); // Tạo ứng dụng

// Cấu hình HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Đặt route mặc định đến trang đăng nhập
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run(); // Chạy ứng dụng
