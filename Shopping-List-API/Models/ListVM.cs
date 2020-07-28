using Shopping_List_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_List_API.Entities
{
    public class ListVM
    {
        public long ListId { get; set; }
        public string AccountId { get; set; }

        public ICollection<ListItem> ListItems{ get; set; }
        public AccountVM Account { get; set; }
    }
}
