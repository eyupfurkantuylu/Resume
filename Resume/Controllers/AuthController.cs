using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Resume.Models.Dtos.AuthDtos;
using Resume.Repositories.AdminRepositories.AuthRepositories;

namespace Resume.Controllers
{

    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IAuthRepository authRepository, IHttpContextAccessor httpContextAccessor)
        {
            _authRepository = authRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginDto adminLoginDto)
        {
            var result = await _authRepository.Login(adminLoginDto);
            if (result.Success == true)
            {
                _httpContextAccessor.HttpContext.Session.SetString("Email", adminLoginDto.Email);
                _httpContextAccessor.HttpContext.Session.SetInt32("ID", adminLoginDto.ID);
        
                // Kullanıcı oturumu doldur
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, adminLoginDto.Email),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // "Beni hatırla" işaretli mi?
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                
                
                return RedirectToAction("Index", "Admin"); 
            }
    
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Auth");
        }
        
        
        
    }

}