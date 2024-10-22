using AutoMapper;
using e_learning.DAL.Data;
using e_learning.DAL.Models;
using e_learning.PL.Areas.Dashboard.ViewModels;
using e_learning.PL.Areas.Dashboard.ViewModels.CategoryViewModels;
using e_learning.PL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_learning.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles="Admin,SuperAdmin")]
    [Area("Dashboard")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CategoryController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            var categoriesViewModel = mapper.Map<IEnumerable<CategoriesViewModel>>(categories);

            ViewData["email"] = "ali@gmail.com";
            ViewBag.userName = "ali";
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
            categoryFormViewModel.ImageName = FilesSetting.UploadFile(categoryFormViewModel.Image, "Images");
            Console.WriteLine(categoryFormViewModel.ImageName);
            var category = mapper.Map<Category>(categoryFormViewModel);
            context.Add(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDetailsViewModel = mapper.Map<CategoryDetailsViewModel>(category);
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


        //[HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var category = context.Categories.Find(Id);
            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(category.ImageName, "images");
            context.Categories.Remove(category);
            context.SaveChanges();
            //return RedirectToAction(nameof(Index));
            return Ok(new {message="category is deleted successfully"});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryEditViewModel = mapper.Map<CategoryEditViewModel>(category);
            return View(categoryEditViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryEditViewModel categoryEditViewModel)
        {
            var categoryInDatabase = context.Categories.Find(categoryEditViewModel.Id);
            if(categoryInDatabase == null)
            {
                return NotFound();
            }
            if(categoryEditViewModel.Image == null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(categoryInDatabase.ImageName, "Images");
                categoryEditViewModel.ImageName = FilesSetting.UploadFile(categoryEditViewModel.Image, "Images");

            }

            if (!ModelState.IsValid)
            {
                return View(categoryEditViewModel);
            }
            mapper.Map(categoryEditViewModel, categoryInDatabase);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
