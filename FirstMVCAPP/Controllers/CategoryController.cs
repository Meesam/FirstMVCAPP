using FirstMVCAPP.Data;
using FirstMVCAPP.Models;
using FirstMVCAPP.ViewModel;
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
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = categories;

            return View(categoryViewModel);
        }

        [HttpPost]
        public IActionResult Index(CategoryViewModel categoryViewModel)
        {
            var key = categoryViewModel.SearchKey != null ? categoryViewModel.SearchKey : "";
            if (key != "")
            {
                List<Category> categories = _dbContext.Categories.Where(x => x.Name.Contains(key)).ToList();
                CategoryViewModel _categoryViewModel = new CategoryViewModel();
                _categoryViewModel.Categories = categories;
                return View(_categoryViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public IActionResult AddCategory(int Id)
        {
            if (Id == 0)
            {
                return View();
            }
            else
            {
                Category category = _dbContext.Categories.SingleOrDefault(x => x.Id == Id);
                if (category is null)
                {
                    return NotFound();
                }
                return View(category);
            }

        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0)
                {
                    _dbContext.Categories.Add(category);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Category _category = _dbContext.Categories.SingleOrDefault(a => a.Id == category.Id);
                    if (_category is null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _category.DisplayOrder = category.DisplayOrder;
                        _category.Name = category.Name;
                        _category.Id = category.Id;
                        _dbContext.Categories.Update(_category);
                        _dbContext.SaveChanges();
                        return RedirectToAction("Index");

                    }
                }
            }
            return View();
        }

        public IActionResult DeleteCategory(int Id)
        {
            if (Id <= 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Category _category = _dbContext.Categories.SingleOrDefault(a => a.Id == Id);
                if (_category is null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    _dbContext.Categories.Remove(_category);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
        }
    }
}
