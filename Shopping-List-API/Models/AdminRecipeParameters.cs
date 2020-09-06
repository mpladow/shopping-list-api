using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Models
{
    public class AdminRecipeParameters: QueryStringParameters
    {

	}
    public class RecipeParameters: QueryStringParameters
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
