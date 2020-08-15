﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Shopping_List_API.Entities;
using Shopping_List_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        string GetBase64RecipeImage(string imageName);
    }
    public class AdminRecipeService : IAdminRecipeService
    {
        private MLDevelopmentContext _db;
        private IMapper _mapper;
        private IAzureBlobService _azureBlobService;
        private string imageContainerName = "shopping-app";

        public AdminRecipeService(MLDevelopmentContext db, IMapper mapper, IAzureBlobService azureBlobService)
        {
            _db = db;
            _mapper = mapper;
            _azureBlobService = azureBlobService;
        }

        public bool CreateNewRecipe(RecipeVM recipe)
        {
            try
            {

                var entity = new Recipe();
                entity.CategoryId = recipe.CategoryId;
                entity.Name = recipe.Name;
                entity.DescriptionPrimary = recipe.DescriptionPrimary;
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
                        methodItem.Text = currentMethodItem.Text;
                        methodItem.StepNo = i + 1;
                        entity.MethodItems.Add(methodItem);
                    }
                }

                //add image
                // will be receiving a base64 byte array from front end
                //var file = recipe.Image;
                //_azureBlobService.UploadSingleAsync()
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
            var entity = _db.Recipes
                .Include(rcp => rcp.Category)
                .Include(rcp => rcp.Ingredients)
                .Include(rcp => rcp.MethodItems)
                .FirstOrDefault(rcp => rcp.RecipeId == recipe.RecipeId);

            // edit existing entity
            if (entity == null)
                entity = new Recipe();

            _mapper.Map(recipe, entity);
            entity.Category = _db.Categories.FirstOrDefault(c => c.CategoryId == recipe.CategoryId);
            _db.Recipes.Update(entity);

            //remove existing values from lists
            foreach (var ingredient in entity.Ingredients.ToList())
            {
                entity.Ingredients.Remove(ingredient);
            }
            foreach (var methodItem in entity.MethodItems.ToList())
            {
                entity.MethodItems.Remove(methodItem);
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
                    entity.Ingredients.Add(ingredient);
                }
            }
            for (int i = 0; i < recipe.MethodItems.Count; i++)
            {
                var currentMethodItem = recipe.MethodItems[i];
                if (!string.IsNullOrEmpty(currentMethodItem.Text))
                {
                    var methodItem = new MethodItem();
                    methodItem.Text = currentMethodItem.Text;
                    methodItem.StepNo = i + 1;
                    entity.MethodItems.Add(methodItem);
                }
            }

            // remove the existing image file from Azure
            if (entity.ImageUrl != null)
                _azureBlobService.DeleteByNameAsync(entity.ImageUrl, imageContainerName);

            // trim file to convert to base64
            if (!string.IsNullOrEmpty(recipe.ImageFile))
            {
                var base64 = recipe.ImageFile.Substring(recipe.ImageFile.LastIndexOf(',') + 1);
                byte[] imageBytes = Convert.FromBase64String(base64);

                using (var stream = new MemoryStream(imageBytes))
                {
                    IFormFile file = new FormFile(stream, 0, imageBytes.Length, "", "");
                    var fileNameTask = _azureBlobService.UploadSingleAsync(file, imageContainerName);
                    entity.ImageUrl = fileNameTask.Result;
                }
            }

            _db.Recipes.Update(entity);
            
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
            var recipe = _db.Recipes.Include(rcp => rcp.Ingredients)
                .Include(rcp => rcp.MethodItems)
                .FirstOrDefault(rcp => rcp.RecipeId == id);

            // order the recipe items and ingredients by correct order
            recipe.Ingredients = recipe.Ingredients.OrderBy(i => i.PositionNo).ToList();
            recipe.MethodItems = recipe.MethodItems.OrderBy(mi => mi.StepNo).ToList();
            return recipe;
        }
        public string GetBase64RecipeImage(string fileName)
        {
            var base64 = _azureBlobService.GetBase64ByNameAsync(fileName, imageContainerName);
            return base64.Result;

        }
    }
}
