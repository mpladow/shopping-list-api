using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping_List_API.Entities;
using Shopping_List_API.Models;
using Shopping_List_API.Services;

namespace Shopping_List_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRecipesController : ControllerBase
    {
        private IAdminRecipeService _adminRecipeService;
        private IMapper _mapper;
        public AdminRecipesController(IAdminRecipeService adminRecipeService, IMapper mapper)
        {
            _mapper = mapper;
            _adminRecipeService = adminRecipeService;
        }
        // GET: api/AdminRecipes
        [HttpGet]
        public IEnumerable<RecipeVM> Get([FromQuery]AdminRecipeParameters parameters)
        {
            var adminRecipesFromService = _adminRecipeService.GetAllRecipes(parameters);

            var metadata = new
            {
                adminRecipesFromService.TotalCount,
                adminRecipesFromService.PageSize,
                adminRecipesFromService.CurrentPage,
                adminRecipesFromService.TotalPages,
                adminRecipesFromService.HasNext,
                adminRecipesFromService.HasPrevious
            };

            var list = adminRecipesFromService.Select(r => new RecipeVM
            {
                RecipeId = r.RecipeId,
                Name = r.Name,
                CategoryName = r.Category.Name,
                PublishedAt = r.PublishedAt,
            }).ToList();

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return list;
        }

        // GET: api/AdminRecipes/5
        [HttpGet("{id}")]
        public RecipeVM Get(int id)
        {
            var recipeFromDb = _adminRecipeService.GetRecipeById(id);
            var model = new RecipeVM();
            _mapper.Map(recipeFromDb, model);
            return model;
        }

        // POST: api/AdminRecipes
        [HttpPost]
        public IActionResult Post([FromBody] RecipeVM recipe)
        {
            try
            {
                var response = false;
                if (recipe.RecipeId > 0)
                {
                    response = _adminRecipeService.EditRecipe(recipe);
                }
                else
                {
                    //use service to create new recipe and add to db.
                    response = _adminRecipeService.CreateNewRecipe(recipe);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/AdminRecipes/5
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
