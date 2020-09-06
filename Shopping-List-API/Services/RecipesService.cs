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
        string GetBase64RecipeImage(string fileName);
        string GetUri(string fileName);
        List<Uri> GetAllUrisByContainer();
        PagedList<Recipe> GetRecipesByQuery(RecipeParameters recipeParameters); 
    }
    public class RecipesService : IRecipesService
    {
        private MLDevelopmentContext _db;
        private IAzureBlobService _azureBlobService;
        private string imageContainerName = "shopping-app";

        public RecipesService(MLDevelopmentContext db, IAzureBlobService azureBlobService)
        {
            _db = db;
            _azureBlobService = azureBlobService;

        }

        public PagedList<Recipe> GetAllRecipes(RecipeParameters recipeParameters)
        {
            return PagedList<Recipe>.ToPagedList(_db.Recipes
                .Include(rcp => rcp.Category)
                .Include(rcp => rcp.Ingredients)
                .Include(rcp => rcp.MethodItems)
                .Where(r => r.DeletedAt == null)
                .Where(r => string.IsNullOrEmpty(recipeParameters.Text) || r.Name.Contains(recipeParameters.Text) || r.Category.Name.Contains(recipeParameters.Text)),
                recipeParameters.PageNumber,
                recipeParameters.PageSize);
        }
        public Recipe GetRecipeById(int id)
        {
            var recipe = _db.Recipes
                .Include(r => r.Category)
                .Include(r => r.MethodItems)
                .Include(r => r.Ingredients)
                .FirstOrDefault(r => r.RecipeId == id);
            return recipe;
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
        // IMAGE LOADING FROM AZURE STORAGE
        public string GetBase64RecipeImage(string fileName)
        {
            var base64 = _azureBlobService.GetBase64ByNameAsync(fileName, imageContainerName);
            return base64.Result;
        }
        public string GetUri(string fileName)
        {
            var url = _azureBlobService.GetUriByNameAsync(fileName, imageContainerName);
            return url.Result.AbsoluteUri;
        }
        public List<Uri> GetAllUrisByContainer()
        {
            var list = _azureBlobService.GetMultipleUriByContainerAsync(imageContainerName);
            return list.Result.ToList();
        }

        public PagedList<Recipe> GetRecipesByQuery(RecipeParameters recipeParameters)
        {
            throw new NotImplementedException();
        }
    }
}
