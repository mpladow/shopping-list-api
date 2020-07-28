using Microsoft.EntityFrameworkCore;
using Shopping_List_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public interface IRecipesService
    {
        List<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);
    }
    public class RecipesService : IRecipesService
    {
        private MLDevelopmentContext _db;

        public RecipesService(MLDevelopmentContext db)
        {
            _db = db;
        }

        public List<Recipe> GetAllRecipes()
        {
            var recipes = _db.Recipes
                .Where(x => !x.DeletedAt.HasValue)
                .Where(x => x.PublishedAt.HasValue)
                .Include(recipe => recipe.Ingredients)
                .Include(recipe => recipe.MethodItems)
                .ToList();
            return recipes;
        }
        public Recipe GetRecipeById(int id)
        {
            return _db.Recipes.Find(id);
        }
    }
}
