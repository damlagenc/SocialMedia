using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using System.Linq;
using System.Security.Claims;

namespace SocialMedia.Controllers
{
    public class ProfileController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public ProfileController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            int userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
            User user = _dbContext.Users.Find(userId);

            ViewData["UserName"] = user.UserName;
            ViewData["FullName"] = user.FullName;

            return View();
        }

        [HttpPost]
        public IActionResult ProfileChangeUserName(string username)
        {
            if (ModelState.IsValid)
            {
                int userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
                User user = _dbContext.Users.Find(userId);
                user.UserName = username;
                _dbContext.SaveChanges();

                ViewData["Message"] = "Username has been updated successfully.";
            }

            return RedirectToAction(nameof(Profile));
        }

        [HttpPost]
        public IActionResult ProfileChangePassword(string password)
        {
            if (ModelState.IsValid)
            {
                int userId = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);
                User user = _dbContext.Users.Find(userId);
                user.Password = MD5Sifrele(password);
                _dbContext.SaveChanges();

                ViewData["Message"] = "Password has been changed successfully.";
            }

            return RedirectToAction(nameof(Profile));
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

