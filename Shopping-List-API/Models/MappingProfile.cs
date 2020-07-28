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
            CreateMap<Recipe, RecipeVM>();
            CreateMap<RecipeVM, Recipe>();
            CreateMap<RecipeListItemVM, Recipe>();
            CreateMap<Recipe, RecipeListItemVM>();
            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();
        }
    }
}
