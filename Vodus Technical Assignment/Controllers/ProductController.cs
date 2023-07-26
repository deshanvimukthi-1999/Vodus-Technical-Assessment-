using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using Vodus_Technical_Assignment.Models;

namespace Vodus_Technical_Assignment.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _dbContext;

        public ProductController(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // Retrieve the products from the database using the ProductDbContext
            var products = _dbContext.Products.ToList();

            return View(products);
        }

        // New "Create" action method
        public IActionResult Create()
        {
            return View();
        }


        // Handle form submission and add the new product to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
