using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Data;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        //Reference Variable
        private readonly ApplicationDBContext _dbContext;
        //constructor
        public ProductController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //ToList method works as select*from products
            //var prodObject = _dbContext.ToList();

            IEnumerable<Product> product = _dbContext.products;
            return View(product);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product prod)
        {
            if (ModelState.IsValid)
            {
                _dbContext.products.Add(prod);
                _dbContext.SaveChanges();
                TempData["success"] = "Product Added Successfully!!!";
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(prod);
            }
        }

        public IActionResult EditProduct(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDB = _dbContext.products.Find(id);
            if (productFromDB == null)
            {
                return NotFound();
            }
            return View(productFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product prod)
        {
                _dbContext.products.Update(prod);
                _dbContext.SaveChanges();
                TempData["success"] = "Product Updated Successfully!!!";
                return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDB = _dbContext.products.Find(id);
            if (productFromDB == null)
            {
                return NotFound();
            }
            return View(productFromDB);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int? id)
        {
            var productFromDB = _dbContext.products.Find(id);
            if (productFromDB == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.products.Remove(productFromDB);
                _dbContext.SaveChanges(true);
                TempData["success"] = "Product Deleted Successfully!!!";
                return RedirectToAction("Index", "Product");
            }
        }

        [Route("/Product/filter")]
        public IActionResult Index(string search = "")
        {
            Product product = new Product();
            ViewBag.SearchKey = search;
            List<Product> listProduct = _dbContext.products.Where(temp=>temp.ProductName.Contains(search)).ToList();
            return View(listProduct);       
        }


    }
}
