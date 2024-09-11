using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindHCI.NW;

namespace NorthwindHCI.Pages;

public class IndexModel : PageModel
{
    private readonly NorthwindContext _context;

    public IndexModel()
    {
        _context = new();
    }

    public void OnGet()
    {
        var categories = _context.Categories
            .OrderBy(c => c.CategoryId)
            .Select(c => new Category {
                CategoryName = c.CategoryName,
                CategoryId = c.CategoryId
            });
        ViewData["Categories"] = categories.ToList();
        foreach (Category item in categories) {
            Console.WriteLine($"{item.CategoryId}\t{item.CategoryName}");
        };
    }
}
