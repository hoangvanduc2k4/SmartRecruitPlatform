using AutoMapper;
using SmartRecruit.Application.DTO.Category;
using SmartRecruit.Domain.Entities;

namespace SmartRecruit.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResponse>();
        }
    }
}
