namespace e_learning.PL.Areas.Dashboard.ViewModels
{
    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } // for soft delete purpose to show the categories
                                            // has IsDeleted=false
        public DateTime CreatedAt { get; set; }
    }
}
