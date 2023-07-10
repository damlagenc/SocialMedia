using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public RegisterController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var users = _dbContext.Users.ToList(); // Users tablosundan verileri çekiyoruz
            return View(users);
        }
      
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register([FromForm] User model)
        {
            if (_dbContext.Users.Any(c => c.Email.Equals(model.Email) && c.UserName.Equals(model.UserName)))
            {
                ModelState.AddModelError("", "This user is already registered.");
                return View(model);
            }
            
            if (ModelState.IsValid)
            {
                 // UTC zaman dilimindeki mevcut zamanı atar
                model.RegisterAt = DateTime.UtcNow;
                model.Password = MD5Sifrele(model.Password); // Şifreyi MD5 ile şifrele
                _dbContext.Users.Add(model);
                _dbContext.SaveChanges();
                return View("Feedback", model);
            }
            
            return View(model);
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
    }
}
