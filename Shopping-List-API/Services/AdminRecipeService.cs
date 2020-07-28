using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Shopping_List_API.Entities;
using Shopping_List_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public interface IAdminRecipeService
    {
        List<Recipe> GetAllRecipes();
        Recipe GetRecipeById(int id);
        bool CreateNewRecipe(RecipeVM recipe);
    }
    public class AdminRecipeService : IAdminRecipeService
    {
        private MLDevelopmentContext _db;

        public AdminRecipeService(MLDevelopmentContext db)
        {
            _db = db;
        }

        public bool CreateNewRecipe(RecipeVM recipe)
        {
            var entity = new Recipe();
            try
            {
                entity.CategoryId = recipe.CategoryId.Value;
                entity.Name = recipe.Name;
                entity.DescriptionMain = recipe.DescriptionPrimary;
                entity.DescriptionSecondary = recipe.DescriptionSecondary;
                entity.Ingredients = new List<Ingredient>();
                for (int i = 0; i < recipe.Ingredients.Count; i++)
                {
                    var ingredient = new Ingredient();
                    ingredient.Name = recipe.Ingredients[i].Name;
                    ingredient.Measure = recipe.Ingredients[i].Measure;
                    ingredient.Quantity = recipe.Ingredients[i].Quantity.Value;
                    ingredient.PositionNo = i + 1;
                    entity.Ingredients.Add(ingredient);
                }
                entity.MethodItems = new List<MethodItem>();
                for (int i = 0; i < recipe.MethodItems.Count; i++)
                {
                    var methodItem = new MethodItem();
                    methodItem.Text = recipe.MethodItems[i].Text;
                    methodItem.StepNo = i + 1;
                    entity.MethodItems.Add(methodItem);
                }
                _db.Recipes.Add(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                
            }

        }

        public List<Recipe> GetAllRecipes()
        {
            return _db.Recipes
                .Where(r=> r.DeletedAt == null)
                .ToList();
        }

        public Recipe GetRecipeById(int id)
        {
            return _db.Recipes.Find(id);
        }
    }
}
