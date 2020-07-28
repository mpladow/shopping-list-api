using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Entities
{
    [Table("ListItem", Schema = "rcp")]
    public class ListItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ListItemId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime? IsDeleted { get; set; }
        public DateTime? IsComplete { get; set; }
        public int Order { get; set; }
        public virtual List List { get; set; }

    }
}
