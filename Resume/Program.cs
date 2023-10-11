using Resume.Models.DapperContext;
using Resume.Repositories.AboutRepositories;
using Resume.Repositories.AwardsRepositories;
using Resume.Repositories.ContactRepositories;
using Resume.Repositories.EducationRepositories;
using Resume.Repositories.ExperienceRepositories;
using Resume.Repositories.HobbyRepositories;
using Resume.Repositories.SkillRepositories;

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