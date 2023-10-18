using Resume.Models.DapperContext;
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();