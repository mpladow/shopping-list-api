using Microsoft.EntityFrameworkCore;
using Shopping_List_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
    }
    public class CategoryService : ICategoryService
    {
        private MLDevelopmentContext _db;

        public CategoryService(MLDevelopmentContext db)
        {
            _db = db;
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }
    }
}
