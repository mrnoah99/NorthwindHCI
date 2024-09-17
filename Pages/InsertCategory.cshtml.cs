using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindHCI.NW;

namespace NorthwindHCI.Pages
{

    /// <summary>
    /// The backend / code side for the InsertCategory page
    /// Author: Teddy Dumam-Ag A01329707
    /// Date: 2024-09-16
    /// </summary>
    public class InsertCategoryModel : PageModel
    {
        // Get the database context from the dependency injection container
        private readonly NorthwindContext _context;

        // Bind properties for the form fields
        [BindProperty]
        public string Category_Name { get; set; } // Bind the Category_Name property to the form field with the same name

        [BindProperty]
        public string CategoryDescription { get; set; } // Bind the CategoryDescription property to the form field with the same name

        // Initalize the database context in the constructor
        public InsertCategoryModel()
        {
            _context = new();
        }

        public void OnGet()
        {
        }

        // Handle the form post submission
        public void OnPost()
        {
            var category = new Category // Create a new category object
            {
                CategoryName = Category_Name, // with the CategoryName property set to the value of the Category_Name property
                Description = CategoryDescription // and the Description property set to the value of the CategoryDescription property
            };
            _context.Categories.Add(category); // then add to database
            _context.SaveChanges(); // save
            ViewData["Message"] = $"Category {Category_Name} with {CategoryDescription} added successfully!"; // move to a variable
        }

    }
}
