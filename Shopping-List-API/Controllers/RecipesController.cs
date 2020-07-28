using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<RecipeVM> GetPublishedRecipes()
        {
            var recipeFromService = _recipesService.GetAllRecipes();

            var result = _mapper.Map<List<RecipeVM>>(recipeFromService);

            return result;
        }

        // GET: api/Recipes/5
        public string Get(int id)
        {
            return "value";
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
