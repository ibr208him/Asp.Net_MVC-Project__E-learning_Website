using AutoMapper;
using e_learning.DAL.Data;
using e_learning.DAL.Data.Models;
using e_learning.PL.Areas.Dashboard.ViewModels.CategoryViewModels;
using e_learning.PL.Areas.Dashboard.ViewModels.CourseViewModels;
using e_learning.PL.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace e_learning.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CourseController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var courses=context.Courses.ToList();
            var coursesCardViewModel = mapper.Map< IEnumerable < CourseCardViewModel >> (courses);
            return View(coursesCardViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories=context.Categories.ToList();
            var courseFormViewModel = new CourseFormViewModel
            {
                Categories = new SelectList(categories, "Id", "Name")
            };

            return View(courseFormViewModel);

            //var courseFormViewModel = new CourseFormViewModel
            //{
            //    Categories = mapper.Map<IEnumerable<CategoriesViewModel>>(categories)
            //};
            //return View(courseFormViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseFormViewModel courseFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(courseFormViewModel);
            }
            courseFormViewModel.ImageName = FilesSetting.UploadFile(courseFormViewModel.Image, "Images");
            Console.WriteLine(courseFormViewModel.ImageName);
            var course = mapper.Map<Course>(courseFormViewModel);
            context.Add(course);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            var courseDetailsViewModel = mapper.Map<CourseDetailsViewModel>(course);
            return View(courseDetailsViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            var cousrseCardViewModel = mapper.Map<CourseCardViewModel>(course);
            return View(cousrseCardViewModel);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int Id)
        {
            var course = context.Courses.Find(Id);
            if (course == null)
            {
                return RedirectToAction(nameof(Index));
            }
            FilesSetting.DeleteFile(course.ImageName, "images");
            context.Courses.Remove(course);
            context.SaveChanges();
            //return RedirectToAction(nameof(Index));
            return Ok(new { message = "course is deleted successfully" });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Courses.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            var courseEditViewModel = mapper.Map<CourseEditViewModel>(category);
            return View(courseEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseEditViewModel courseEditViewModel)
        {
            var courseInDatabase = context.Courses.Find(courseEditViewModel.Id);
            if (courseInDatabase == null)
            {
                return NotFound();
            }
            if (courseEditViewModel.Image == null)
            {
                ModelState.Remove("Image");
            }
            else
            {
                FilesSetting.DeleteFile(courseInDatabase.ImageName, "Images");
                courseEditViewModel.ImageName = FilesSetting.UploadFile(courseEditViewModel.Image, "Images");

            }

            if (!ModelState.IsValid)
            {
                return View(courseEditViewModel);
            }
            mapper.Map(courseEditViewModel, courseInDatabase);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


    }
}
