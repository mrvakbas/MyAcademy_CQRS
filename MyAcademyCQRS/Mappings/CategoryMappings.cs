using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;
using MyAcademyCQRS.Entities;
using MyAcademyCQRS.Models;

namespace MyAcademyCQRS.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, GetCategoriesQueryResult>();
            CreateMap<AppUser, ResultUserDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
