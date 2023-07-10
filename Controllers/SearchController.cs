using Microsoft.AspNetCore.Mvc;
using SocialMedia;

public class SearchController : Controller
{
    private readonly DatabaseContext _dbContext;

    public SearchController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index(string query)
    {
        // Arama sorgusu ile ilgili işlemleri gerçekleştirin
        // Sonuçları bir modelde toplayın ve view'e gönderin
        var searchResults = _dbContext.Users
            .Where(u => u.UserName.Contains(query) || u.FullName.Contains(query))
            .ToList();

        return View(searchResults);
    }
}
