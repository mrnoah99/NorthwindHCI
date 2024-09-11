using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindHCI.NW;

namespace NorthwindHCI.Pages
{

    public class InsertCategoryModel : PageModel
    {
        private readonly NorthwindContext _context;

        public int MyProperty { get; set; }

        [BindProperty]
        public string Category_Name { get; set; }

        [BindProperty]
        public string CategoryDescription { get; set; }

        public InsertCategoryModel()
        {
            _context = new();
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Console.WriteLine($"Category Name: {Category_Name} and Description: {CategoryDescription}");
            var category = new Category
            {
                CategoryName = Category_Name,
                Description = CategoryDescription
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            ViewData["Message"] = $"Category {Category_Name} with {CategoryDescription} added successfully!";
        }

    }
}
