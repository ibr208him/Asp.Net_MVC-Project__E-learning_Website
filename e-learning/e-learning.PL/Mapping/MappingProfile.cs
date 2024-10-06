using AutoMapper;
using e_learning.DAL.Data.Models;
using e_learning.PL.Areas.Dashboard.ViewModels;

namespace e_learning.PL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryFormViewModel, Category>();
            CreateMap<Category, CategoriesViewModel>();
            CreateMap<Category, CategoryDetailsViewModel>();
        }
    } 
}
