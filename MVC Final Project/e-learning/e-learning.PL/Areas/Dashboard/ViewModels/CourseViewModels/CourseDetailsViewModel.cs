namespace e_learning.PL.Areas.Dashboard.ViewModels.CourseViewModels
{
    public class CourseDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } // for soft delete purpose to show the categories
                                            // has IsDeleted=false
        public DateTime CreatedAt { get; set; }
        public string? ImageName { get; set; }
        public double Price { get; set; }
        public double DiscountedPrice { get; set; }
    }
}
