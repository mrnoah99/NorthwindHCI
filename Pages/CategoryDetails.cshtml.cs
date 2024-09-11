using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindHCI.NW;

namespace NorthwindHCI.Pages
{
    
    public class CategoryDetailsModel : PageModel
    {
        private readonly NorthwindContext _context;

        public CategoryDetailsModel() {
            _context = new();
        }

        public void OnGet(int categoryIndex)
        {
            var categories = _context.Categories
            .OrderBy(c => c.CategoryId)
            .Select(c => new Category {
                CategoryName = c.CategoryName,
                CategoryId = c.CategoryId,
                Description = c.Description
            });
            ViewData["Category"] = categories.ToList()[categoryIndex];
        }
    }
}
