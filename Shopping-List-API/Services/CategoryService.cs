using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Shopping_List_API.Entities;
using Shopping_List_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        string GetBase64Image(string fileName);
        string GetUri(string fileName);
        List<Uri> GetAllUrisByContainer();
        int NewCategory(CategoryVM model);
        int EditCategory(CategoryVM model);
        bool SetOrder(List<CategoryVM> model);

    }
    public class CategoryService : ICategoryService
    {
        private MLDevelopmentContext _db;
        private IAzureBlobService _azureBlobService;
        private IMapper _mapper;
        private string imageContainerName = "shopping-app-categories";


        public CategoryService(MLDevelopmentContext db, IMapper mapper, IAzureBlobService azureBlobService)
        {
            _db = db;
            _azureBlobService = azureBlobService;
            _mapper = mapper;
        }

        public int EditCategory(CategoryVM model)
        {
            var entity = _db.Categories.FirstOrDefault(c => c.CategoryId == model.CategoryId);

            if (entity != null)
            {
                _mapper.Map(model, entity);

                // trim file to convert to base64
                if (!string.IsNullOrEmpty(model.ImageBase64))
                {
                    var base64 = model.ImageBase64.Substring(model.ImageBase64.LastIndexOf(',') + 1);
                    byte[] imageBytes = Convert.FromBase64String(base64);

                    using (var stream = new MemoryStream(imageBytes))
                    {
                        IFormFile file = new FormFile(stream, 0, imageBytes.Length, "", "");
                        var fileNameTask = _azureBlobService.UploadSingleAsync(file, imageContainerName);
                        entity.ImageUrl = fileNameTask.Result;
                    }
                    _db.Categories.Update(entity);
                    _db.SaveChanges();
                }
            }
            return entity.CategoryId;
        }
        public bool SetOrder(List<CategoryVM> model)
        {
            for (int i = 0; i < model.Count; i++)
            {
                var entity = _db.Categories.FirstOrDefault(c => c.CategoryId == model[i].CategoryId);

                if (entity != null)
                {
                    _mapper.Map(model[i], entity);

                    // trim file to convert to base64
                    entity.Order = i + 1;

                    _db.Categories.Update(entity);
                    _db.SaveChanges();
                }

            }
            return true;
        }

        public List<Category> GetAllCategories()
        {
            return _db.Categories.OrderBy(c => c.Order).ToList();
        }
        public string GetBase64Image(string fileName)
        {
            var base64 = _azureBlobService.GetBase64ByNameAsync(fileName, imageContainerName);
            return base64.Result;
        }
        public string GetUri(string fileName)
        {
            var url = _azureBlobService.GetUriByNameAsync(fileName, "shopping-app-categories");
            return url.Result.AbsoluteUri;
        }
        public List<Uri> GetAllUrisByContainer()
        {
            var list = _azureBlobService.GetMultipleUriByContainerAsync(imageContainerName);
            return list.Result.ToList();
        }


        public Category GetCategoryById(int id)
        {
            return _db.Categories.FirstOrDefault(c => c.CategoryId == id);

        }

        public int NewCategory(CategoryVM model)
        {
            var entityExists = _db.Categories.Any(c => c.CategoryId == model.CategoryId || c.Name.ToLower() == model.Name.ToLower());

            var id = 0;
            if (!entityExists)
            {
                var entity = new Category();
                _mapper.Map(model, entity);

                // trim file to convert to base64
                if (!string.IsNullOrEmpty(model.ImageBase64))
                {
                    var base64 = model.ImageBase64.Substring(model.ImageBase64.LastIndexOf(',') + 1);
                    byte[] imageBytes = Convert.FromBase64String(base64);

                    using (var stream = new MemoryStream(imageBytes))
                    {
                        IFormFile file = new FormFile(stream, 0, imageBytes.Length, "", "");
                        var fileNameTask = _azureBlobService.UploadSingleAsync(file, imageContainerName);
                        entity.ImageUrl = fileNameTask.Result;
                    }
                    _db.Categories.Add(entity);
                    _db.SaveChanges();
                    id = entity.CategoryId;
                }
            }
            return id;
        }
    }
}
