using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Models
{
    public class MethodItemVM
    {
        public int? MethodItemId { get; set; }
        public int RecipeId { get; set; }
        public int StepNo { get; set; }
        public string Text { get; set; }
    }
}
