using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore; // Nhập namespace cho Entity Framework Core
using Microsoft.AspNetCore.Identity; // Nhập namespace cho Identity
using WebApplication_GameCaKoi.Models; // Nhập namespace cho mô hình của bạn

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Cấu hình DbContext để sử dụng SQL Server
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Cấu hình Identity với User và IdentityRole
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddControllersWithViews(); // Thêm hỗ trợ cho các Controller với Views
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Hiển thị trang lỗi trong môi trường phát triển
        }
        else
        {
            app.UseExceptionHandler("/Home/Error"); // Xử lý lỗi trong môi trường sản xuất
            app.UseHsts(); // Sử dụng HSTS
        }

        app.UseHttpsRedirection(); // Chuyển hướng đến HTTPS
        app.UseStaticFiles(); // Cho phép phục vụ các tệp tĩnh

        app.UseRouting(); // Sử dụng định tuyến

        app.UseAuthentication(); // Sử dụng xác thực
        app.UseAuthorization(); // Sử dụng ủy quyền

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Định nghĩa điểm cuối cho Controllers
        });
    }
}
