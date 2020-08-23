using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Models
{
    public class IngredientVM
    {
        public int? IngredientId { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public decimal? Quantity { get; set; }
        public string Measure { get; set; }
        public int? PositionNo { get; set; }
        public bool Seperator { get; set; }

    }
}
