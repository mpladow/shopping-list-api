using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_List_API.Models;
using Shopping_List_API.Services;

namespace Shopping_List_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminRecipesController : ControllerBase
    {
        private IAdminRecipeService _adminRecipeService;
        public AdminRecipesController(IAdminRecipeService adminRecipeService)
        {
            _adminRecipeService = adminRecipeService;
        }
        // GET: api/AdminRecipes
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var adminRecipesFromService = _adminRecipeService.GetAllRecipes();
            return new string[] { "value1", "value2" };
        }

        // GET: api/AdminRecipes/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AdminRecipes
        [HttpPost]
        public IActionResult Post([FromBody] RecipeVM recipe)
        {
            try
            {
            //use service to create new recipe and add to db.
            var response = _adminRecipeService.CreateNewRecipe(recipe);
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
