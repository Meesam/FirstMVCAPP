using FirstMVCAPP.Data;
using FirstMVCAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCAPP.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Category> categories = _dbContext.Categories.ToList();
            return View(categories);
        }

        public IActionResult AddCategory()
        {
            return View();
        }
    }
}
