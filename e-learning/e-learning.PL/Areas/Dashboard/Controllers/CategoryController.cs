using AutoMapper;
using e_learning.DAL.Data;
using e_learning.DAL.Data.Models;
using e_learning.PL.Areas.Dashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace e_learning.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var categories=context.Categories.ToList();
            var categoriesViewModel= mapper.Map<IEnumerable<CategoriesViewModel>>(categories);
            return View(categoriesViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryFormViewModel categoryFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryFormViewModel);
            }
            var category = mapper.Map<Category>(categoryFormViewModel);
            context.Add(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            var categoryDetailsViewModel=mapper.Map<CategoryDetailsViewModel>(category);
            return View(categoryDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoriesViewModel = mapper.Map<CategoriesViewModel>(category);
            return View(categoriesViewModel);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        }
}
