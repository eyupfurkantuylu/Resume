using Microsoft.AspNetCore.Authentication.Cookies;
using Resume.Models.DapperContext;
using Resume.Repositories.AdminRepositories.AboutRepositories;
using Resume.Repositories.AdminRepositories.AuthRepositories;
using Resume.Repositories.AdminRepositories.AwardsRepositories;
using Resume.Repositories.AdminRepositories.EducationRepositories;
using Resume.Repositories.AdminRepositories.ExperienceRepositories;
using Resume.Repositories.AdminRepositories.HobbyRepositories;
using Resume.Repositories.AdminRepositories.SkillRepositories;
using Resume.Repositories.AdminRepositories.StatisticsRepositories;
using Resume.Repositories.UIRepositories.AboutRepositories;
using Resume.Repositories.UIRepositories.AwardsRepositories;
using Resume.Repositories.UIRepositories.ContactRepositories;
using Resume.Repositories.UIRepositories.EducationRepositories;
using Resume.Repositories.UIRepositories.ExperienceRepositories;
using Resume.Repositories.UIRepositories.HobbyRepositories;
using Resume.Repositories.UIRepositories.SkillRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<Context>();

builder.Services.AddTransient<IAboutRepository, AboutRepository>();
builder.Services.AddTransient<IExperienceRepository, ExperienceRepository>();
builder.Services.AddTransient<IEducationRepository, EducationRepository>();
builder.Services.AddTransient<ISkillRepository, SkillRepository>();
builder.Services.AddTransient<IHobbyRepository, HobbyRepository>();
builder.Services.AddTransient<IAwardsRepository, AwardsRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<IAdminAboutRepository, AdminAboutRepository>();
builder.Services.AddTransient<IExperienceAdminRepository, ExperienceAdminRepository>();
builder.Services.AddTransient<IEducationAdminRepository, EducationAdminRepository>();
builder.Services.AddTransient<ISkillAdminRepository, SkillAdminRepository>();
builder.Services.AddTransient<IHobbyAdminRepository, HobbyAdminRepository>();
builder.Services.AddTransient<IAwardsAdminRepository, AwardsAdminRepository>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();

// ConfigureServices metodunda Session'ı ekleyin
builder.Services.AddDistributedMemoryCache(); // Örnek olarak MemoryCache kullanabilirsiniz.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Oturum süresini ayarlayabilirsiniz.
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Auth/Login"; // Giriş sayfasının URL'si
    options.AccessDeniedPath = "/Auth/AccessDenied"; // Erişim reddedildi sayfasının URL'si
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




// Configure metodunda Session'ı kullanılabilir hale getirin
app.UseSession();

//İŞE YARAMAZ İSE KALDIRILACAK KISIM
//İŞE YARAMAZ İSE KALDIRILACAK KISIM
//İŞE YARAMAZ İSE KALDIRILACAK KISIM
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();