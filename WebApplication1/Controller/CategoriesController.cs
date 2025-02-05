using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.getCategories();

            return View(categories);
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit"; 
            var category = CategoriesRepository.GetCategorybyId(id.HasValue ? id.Value : null);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));

            }
            return View(category);
        }
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int categoryID)
        {
            CategoriesRepository.DeleteCategory(categoryID);
            return RedirectToAction(nameof(Index));
        }
    }
}
 