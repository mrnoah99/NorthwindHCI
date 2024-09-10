using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindHCI.NW;

namespace NorthwindHCI.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly NorthwindContext _context;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _context = new();
    }

    public void OnGet()
    {
        var categories = _context.Categories
            .Select(c => new Category {
                CategoryName = c.CategoryName
            });
        _logger.LogWarning(categories.Count().ToString());
        ViewData["Categories"] = categories.ToList();
    }
}
