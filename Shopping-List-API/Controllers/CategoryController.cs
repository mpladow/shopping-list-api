using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Shopping_List_API.Entities;
using Shopping_List_API.Models;
using Shopping_List_API.Services;

namespace Shopping_List_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IMapper _mapper;
        private ICategoryService _categoryService;
        public CategoryController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        // GET: api/Category
        [HttpGet]
        public IEnumerable<CategoryVM> Get()
        {
            var categoriesFromService = _categoryService.GetAllCategories();

            // map the values to vm
            var model = _mapper.Map<List<CategoryVM>>(categoriesFromService);
            model.ForEach(c =>
            {
                if (c.ImageUrl != null)
                {
                    c.ImageBase64 = _categoryService.GetBase64Image(c.ImageUrl);
                }
            });
            return model;
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public CategoryVM Get(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            var model = new CategoryVM();
            _mapper.Map(category, model);
            if (category.ImageUrl != null)
            {
                model.ImageBase64 = _categoryService.GetBase64Image(category.ImageUrl);
            }
            return model;
        }

        // POST: api/Category
        [HttpPost]
        public int Post([FromBody] CategoryVM model)
        {
            var categoryId = model.CategoryId;
            if (model.CategoryId > 0)
            {
                categoryId = _categoryService.EditCategory(model);
            }
            else
            {
                categoryId = _categoryService.NewCategory(model);
            }
            return categoryId;
        }

        // PUT: api/Category/5
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
