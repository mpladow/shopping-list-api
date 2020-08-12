using Microsoft.EntityFrameworkCore;
using Shopping_List_API.Entities;
using Shopping_List_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public interface IRecipesService
    {
        PagedList<Recipe> GetAllRecipes(RecipeParameters recipeParameters);
        Recipe GetRecipeById(int id);
        PagedList<Recipe> GetRecipesByCategory(RecipeParameters recipeParameters);
    }
    public class RecipesService : IRecipesService
    {
        private MLDevelopmentContext _db;

        public RecipesService(MLDevelopmentContext db)
        {
            _db = db;
        }

        public PagedList<Recipe> GetAllRecipes(RecipeParameters recipeParameters)
        {
            return PagedList<Recipe>.ToPagedList(_db.Recipes
                .Include(rcp => rcp.Category)
                .Include(rcp => rcp.Ingredients)
                .Include(rcp => rcp.MethodItems)
                .Where(r => r.DeletedAt == null),
                recipeParameters.PageNumber,
                recipeParameters.PageSize);
        }
        public Recipe GetRecipeById(int id)
        {
            return _db.Recipes
                .Include(r => r.Category)
                .Include(r => r.MethodItems)
                .Include(r => r.Ingredients)
                .FirstOrDefault(r => r.RecipeId == id);
        }
        public PagedList<Recipe> GetRecipesByCategory(RecipeParameters recipeParameters)
        {
            return PagedList<Recipe>.ToPagedList(_db.Recipes
                .Include(rcp => rcp.Category)
                .Include(rcp => rcp.Ingredients)
                .Include(rcp => rcp.MethodItems)
                .Where(r => r.DeletedAt == null)
                .Where(r => r.CategoryId == recipeParameters.Id),
                recipeParameters.PageNumber,
                recipeParameters.PageSize);
        }
    }
}
