using Koi_Game_Reposities.Interfaces; // Thêm các không gian tên cần thiết
using Koi_Game_Services.Interfaces;
using Koi_Game_Services.Class;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Koi_Game_Reposities.Class;

namespace Koi_Game_Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Thêm các dịch vụ cần thiết cho ứng dụng
            services.AddControllersWithViews();

            // Đăng ký các dịch vụ của bạn
            services.AddScoped<IPlayerService, PlayerService>(); // Thêm PlayerService
            services.AddScoped<INapTienService, NapTienService>(); // Thêm NapTienService
            services.AddScoped<ILoginService, LoginService>(); // Đăng ký ILoginService

            // Thêm các repository
            services.AddScoped<IPlayerRepository, PlayerRepository>(); // Thay thế với tên repository của bạn
            // services.AddScoped<IOtherRepository, OtherRepository>(); // Thêm các repository khác nếu có
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Sử dụng trang lỗi phát triển
            }
            else
            {
                app.UseExceptionHandler("/Home/Error"); // Chuyển hướng lỗi đến trang lỗi
                app.UseHsts(); // Sử dụng HSTS
            }

            app.UseHttpsRedirection(); // Chuyển hướng HTTPS
            app.UseStaticFiles(); // Cho phép các file tĩnh

            app.UseRouting(); // Sử dụng routing

            app.UseAuthorization(); // Sử dụng xác thực

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); // Thiết lập route mặc định
            });
        }
    }
}
