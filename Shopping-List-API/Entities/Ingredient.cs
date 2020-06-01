using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Entities
{
    [Table("Ingredient", Schema = "rcp")]
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IngredientId { get; set; }
        public string RecipeId { get; set; }
        public string Name { get; set; }
        public DateTime Quantity { get; set; }
        public string Measure { get; set; }

        public Recipe Recipe { get; set; }
    }
}
