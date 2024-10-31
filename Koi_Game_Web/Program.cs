using Koi_Game_Reposities.Class;
using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Class;
using Koi_Game_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cấu hình database
builder.Services.AddDbContext<KoiGameDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql")));

// Đăng ký player repository
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

// Đăng ký services
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<INapTienService, NapTienService>(); // Đăng ký NapTienService

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();