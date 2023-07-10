using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Controllers
{
    public class PostController : Controller
    {
        private readonly DatabaseContext _dbContext;

        public PostController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Post()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult Create(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                ModelState.AddModelError("Content", "Post content is required.");
                return RedirectToAction(nameof(Index));
            }

            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = _dbContext.Users.FirstOrDefault(u => u.UserId == userId);

            var post = new Post
            {
                Content = content,
                CreatedAt = DateTime.UtcNow,
                User = user
            };

            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
         */
    }
   
}
