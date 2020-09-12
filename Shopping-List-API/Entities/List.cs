using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Entities
{
    [Table("List", Schema = "rcp")]
    public class List
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ListId { get; set; }
        public string ListName { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<ListItem> ListItems{ get; set; }
    }
}
