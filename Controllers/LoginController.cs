using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    public class LoginController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public LoginController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromForm] User model)
        {
            //Şifreyi MD5 ile şifrele
            var password = MD5Sifrele(model.Password);
            // Kullanıcıyı doğrula
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == model.UserName && u.Password == password);

            if (user != null)
            {
                if (user.Locked)
                {
                    ModelState.AddModelError(nameof(model.UserName), "User is locked");
                    ModelState.Remove("Email");
                    ModelState.Remove("LastName");
                    ModelState.Remove("FirstName");

                    return View(model);
                }

            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
                // Diğer hata mesajlarını temizle
                ModelState.Remove("Email");
                ModelState.Remove("Password");
                ModelState.Remove("FirstName");
                ModelState.Remove("LastName");
                ModelState.Remove("Username");
                return View();
            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName ?? string.Empty),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim("UserName", user.UserName)
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            // Kullanıcı girişi başarılı, işlemlere devam et
            return RedirectToAction("Post", "Post");
        }
        public string MD5Sifrele(string metin)
        {
            if (string.IsNullOrEmpty(metin))
                return string.Empty;

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(metin));
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
       [Authorize]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

    }
}
