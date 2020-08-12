using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Shopping_List_API.Entities;
using Shopping_List_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public interface IAdminRecipeService
    {
        PagedList<Recipe> GetAllRecipes(AdminRecipeParameters adminRecipeParameters);
        Recipe GetRecipeById(int id);
        bool CreateNewRecipe(RecipeVM recipe);
        bool EditRecipe(RecipeVM recipe);
    }
    public class AdminRecipeService : IAdminRecipeService
    {
        private MLDevelopmentContext _db;
        private IMapper _mapper;

        public AdminRecipeService(MLDevelopmentContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public bool CreateNewRecipe(RecipeVM recipe)
        {
            try
            {

                var entity = new Recipe();
                entity.CategoryId = recipe.CategoryId.Value;
                entity.Name = recipe.Name;
                entity.DescriptionMain = recipe.DescriptionPrimary;
                entity.DescriptionSecondary = recipe.DescriptionSecondary;
                entity.Ingredients = new List<Ingredient>();
                for (int i = 0; i < recipe.Ingredients.Count; i++)
                {
                    var currentIngredient = recipe.Ingredients[i];
                    if (!string.IsNullOrEmpty(currentIngredient.Name))
                    {
                        var ingredient = new Ingredient();
                        ingredient.Name = currentIngredient.Name;
                        ingredient.Measure = currentIngredient.Measure;
                        ingredient.Quantity = currentIngredient.Quantity;
                        ingredient.PositionNo = i + 1;
                        entity.Ingredients.Add(ingredient);
                    }
                }
                entity.MethodItems = new List<MethodItem>();
                for (int i = 0; i < recipe.MethodItems.Count; i++)
                {
                    var currentMethodItem = recipe.MethodItems[i];
                    if (!string.IsNullOrEmpty(currentMethodItem.Text))
                    {
                        var methodItem = new MethodItem();
                        methodItem.Text = recipe.MethodItems[i].Text;
                        methodItem.StepNo = i + 1;
                        entity.MethodItems. Add(methodItem);
                    }
                }
                _db.Recipes.Add(entity);
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                var xx = e;
                return false;

            }

        }

        public bool EditRecipe(RecipeVM recipe)
        {
            var entityInDb = _db.Recipes
                .Include(rcp => rcp.Ingredients)
                .Include(rcp => rcp.MethodItems)
                .FirstOrDefault(rcp => rcp.RecipeId == recipe.RecipeId);

            // edit existing entity
            _mapper.Map(recipe, entityInDb);
            //remove existing values from lists
            foreach (var ingredient in entityInDb.Ingredients )
            {
                entityInDb.Ingredients.Remove(ingredient);
            }
            foreach (var methodItem in entityInDb.MethodItems)
            {
                //entityInDb.MethodItems.(methodItem);
            }

            for (int i = 0; i < recipe.Ingredients.Count; i++)
            {
                var currentIngredient = recipe.Ingredients[i];
                if (!string.IsNullOrEmpty(currentIngredient.Name))
                {
                    var ingredient = new Ingredient();
                    ingredient.Name = currentIngredient.Name;
                    ingredient.Measure = currentIngredient.Measure;
                    ingredient.Quantity = currentIngredient.Quantity;
                    ingredient.PositionNo = i + 1;
                    entityInDb.Ingredients.Add(ingredient);
                }
            }
            _db.SaveChanges();

            return true;
        }

        public PagedList<Recipe> GetAllRecipes(AdminRecipeParameters adminRecipeParameters)
        {
            var xx = _db.Recipes
                .Include(rcp => rcp.Ingredients)
                .Include(rcp => rcp.MethodItems)
                .Where(r => r.DeletedAt == null);

            return PagedList<Recipe>.ToPagedList(_db.Recipes
                .Include(rcp => rcp.Ingredients)
                .Include(rcp => rcp.MethodItems)
                .Where(r => r.DeletedAt == null), 
                adminRecipeParameters.PageNumber, 
                adminRecipeParameters.PageSize);
        }

        public Recipe GetRecipeById(int id)
        {
            return _db.Recipes.Include(rcp => rcp.Ingredients)
                .Include(rcp => rcp.MethodItems)
                .FirstOrDefault(rcp => rcp.RecipeId == id);
        }
    }
}
