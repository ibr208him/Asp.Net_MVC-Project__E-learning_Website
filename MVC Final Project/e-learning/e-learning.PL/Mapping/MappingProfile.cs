using AutoMapper;
using e_learning.DAL.Models;
using e_learning.PL.Areas.Dashboard.ViewModels;
using e_learning.PL.Areas.Dashboard.ViewModels.CategoryViewModels;
using e_learning.PL.Areas.Dashboard.ViewModels.CourseViewModels;

namespace e_learning.PL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryFormViewModel, Category>().ReverseMap();
            CreateMap<Category, CategoriesViewModel>().ReverseMap();
            CreateMap<Category, CategoryDetailsViewModel>().ReverseMap();
            CreateMap<CategoryEditViewModel, Category>().ReverseMap();

            CreateMap<CourseCardViewModel, Course>().ReverseMap();
            CreateMap<CourseFormViewModel, Course>().ReverseMap();
            CreateMap<Course, CourseDetailsViewModel>().ReverseMap();
            CreateMap<CourseEditViewModel, Course>().ReverseMap();
            
        }
    } 
}
