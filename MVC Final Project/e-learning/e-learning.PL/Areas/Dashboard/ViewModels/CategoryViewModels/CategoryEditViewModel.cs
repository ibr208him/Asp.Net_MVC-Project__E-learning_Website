namespace e_learning.PL.Areas.Dashboard.ViewModels.CategoryViewModels
{
    public class CategoryEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } // for soft delete purpose to show the categories
                                            // has IsDeleted=false
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
    }
}
