namespace e_learning.PL.Areas.Dashboard.ViewModels.CategoryViewModels
{
    public class CategoriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } // for soft delete purpose to show the categories
                                            // has IsDeleted=false

    }
}
