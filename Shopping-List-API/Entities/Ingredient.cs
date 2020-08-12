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
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public decimal? Quantity { get; set; }
        public string Measure { get; set; }
        public int PositionNo { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
