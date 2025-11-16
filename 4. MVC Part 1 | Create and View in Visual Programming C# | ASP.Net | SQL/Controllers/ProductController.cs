using Microsoft.AspNetCore.Mvc;
using mvc6.Data;
using mvc6.Models;
using mvc6.Models.Entities;

namespace mvc6.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context; //empty varible which has no connection string + no table

        //dependency injection = constructor:
        public ProductController(ApplicationDbContext context)  //_context = connection + table (no data of table)
        {
            _context = context;
        }

        //view:
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        //insertion:
        public IActionResult Create(AddProduct addProduct)
        {
            try
            {
                Product p = new Product
                {
                    Name = addProduct.Name,
                    Description = addProduct.Description,
                    Price = addProduct.Price
                };
                _context.Products.Add(p);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            } catch
            {
                return View();
            }
        }
    }
}
