using AutoMapper;
using Shopping_List_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Models
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Recipe, RecipeVM>()
                .ForMember(dest => dest.CategoryName, 
                opts => opts.MapFrom(src => src.Category.Name)).ReverseMap();
            //CreateMap<RecipeVM, Recipe>();
            CreateMap<MethodItem, MethodItemVM>().ReverseMap();
            CreateMap<Ingredient, IngredientVM>().ReverseMap();
            CreateMap<Recipe, RecipeListItemVM>().ReverseMap();
            //CreateMap<RecipeListItemVM, Recipe>();
            CreateMap<Category, CategoryVM>().ReverseMap();
            //CreateMap<CategoryVM, Category>();
        }
    }
}
