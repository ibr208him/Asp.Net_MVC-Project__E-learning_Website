using e_learning.DAL.Models;

namespace e_learning.PL.Areas.Dashboard.ViewModels.CourseViewModels
{
    public class CourseCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
        //public int instructorid { get; set; }
        //public Instructor Instructor { get; set; }
    }
}
