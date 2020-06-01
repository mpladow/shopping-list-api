using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Entities
{
    [Table("MethodItem", Schema = "rcp")]
    public class MethodItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MethodItemId { get; set; }
        public string RecipeId { get; set; }
        public string StepNo { get; set; }
        public string Text { get; set; }
        public Recipe Recipe { get; set; }
    }
}
