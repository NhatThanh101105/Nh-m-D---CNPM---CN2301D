using Koi_Game_Reposities.Class;
using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Class;
using Koi_Game_Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// cau hinh database
builder.Services.AddDbContext<KoiGameDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql")));

// dang ki player repo
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();


// dang ki login, player serivce
builder.Services.AddScoped<IPlayerService,PlayerService>   ();
builder.Services.AddScoped<ILoginService, LoginService>();



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
