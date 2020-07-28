using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Models
{

    public class RecipeListItemVM
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string DescriptionPrimary { get; set; }
        public string ImageUrl { get; set; }
    }
    public class RecipeVM
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string DescriptionPrimary { get; set; }
        public string DescriptionSecondary { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public int? CategoryId { get; set; }
        public CategoryVM Category { get; set; }
        public List<MethodItemVM> MethodItems{ get; set; }
        public List<IngredientVM> Ingredients{ get; set; }
    }
}
