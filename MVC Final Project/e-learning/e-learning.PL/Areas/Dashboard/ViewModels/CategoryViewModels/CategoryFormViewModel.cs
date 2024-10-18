namespace e_learning.PL.Areas.Dashboard.ViewModels.CategoryViewModels
{
    public class CategoryFormViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
    }
}
