using e_learning.DAL.Data.Models;
using e_learning.PL.Areas.Dashboard.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace e_learning.PL.Areas.Dashboard.ViewModels.CourseViewModels
{
    public class CourseFormViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }

        public int? CategoryId { get; set; }

        //public IEnumerable<CategoriesViewModel>? Categories { get; set; }
        public SelectList? Categories { get; set; }

        //public int CategoryId { get; set; }
        //public Category Category { get; set; }
        //public int InstructorId { get; set; }
        //public Instructor Instructor { get; set; }
    }
}
