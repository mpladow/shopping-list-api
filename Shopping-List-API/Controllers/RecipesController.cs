using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping_List_API.Models;
using Shopping_List_API.Services;

namespace Shopping_List_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private IRecipesService _recipesService;
        private IMapper _mapper;
        public RecipesController(IRecipesService recipesService, IMapper mapper)
        {
            _recipesService = recipesService;
            _mapper = mapper;
        }
        // GET: api/Recipes
        [HttpGet("GetPublishedRecipes")]
        public IEnumerable<RecipeVM> GetPublishedRecipes([FromQuery]RecipeParameters recipeParameters)
        {
            var recipeFromService = _recipesService.GetAllRecipes(recipeParameters);

            var metaData = new
            {
                recipeFromService.TotalCount,
                recipeFromService.PageSize,
                recipeFromService.CurrentPage,
                recipeFromService.TotalPages,
                recipeFromService.HasNext,
                recipeFromService.HasPrevious
            };
            var list = recipeFromService.Select(r => new RecipeVM
            {
                RecipeId = r.RecipeId,
                Name = r.Name,
                CategoryName = r.Category.Name,
                DescriptionPrimary = r.DescriptionPrimary,
                DescriptionSecondary = r.DescriptionSecondary,
                ImageUrl = r.ImageUrl
            }).ToList();

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return list;
        }

        [HttpGet("GetRecipesByCategory")]
        public IEnumerable<RecipeVM> GetRecipesByCategory([FromQuery]RecipeParameters recipeParameters)
        {
            var recipeFromService = _recipesService.GetRecipesByCategory(recipeParameters);

            var metaData = new
            {
                recipeFromService.TotalCount,
                recipeFromService.PageSize,
                recipeFromService.CurrentPage,
                recipeFromService.TotalPages,
                recipeFromService.HasNext,
                recipeFromService.HasPrevious
            };
            var list = recipeFromService.Select(r => new RecipeVM
            {
                RecipeId = r.RecipeId,
                Name = r.Name,
                CategoryName = r.Category.Name,
                DescriptionPrimary = r.DescriptionPrimary,
                DescriptionSecondary = r.DescriptionSecondary,
                ImageUrl = r.ImageUrl
            }).ToList();
            list.ForEach(r =>
            {
                if (r.ImageUrl != null)
                {
                    var base64 = _recipesService.GetBase64RecipeImage(r.ImageUrl);
                    r.ImageFile = base64;
                }
            });

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return list;
        }


        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public RecipeVM Get(int id)
        {
            var model = new RecipeVM();
            Entities.Recipe recipeFromService = _recipesService.GetRecipeById(id);
            _mapper.Map(recipeFromService, model);
            // get image from azure
            if (model.ImageUrl != null)
            {
                var base64 = _recipesService.GetBase64RecipeImage(model.ImageUrl);
                model.ImageFile = base64;
            }
            model.Ingredients.OrderBy(i => i.PositionNo).ToList();
            model.MethodItems.OrderBy(i => i.StepNo).ToList();
            return model;
        }

        // POST: api/Recipes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Recipes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
